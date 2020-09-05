using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Singleton;
using System;
using System.Threading.Tasks;
using Dongpn.Addressable;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Dongpn.ObjectPool
{
    public class ObjectsLibrary : Singleton<ObjectsLibrary>
    {
        [SerializeField]
        private Dictionary<string, GameObject> preloadPrefabs = new Dictionary<string, GameObject>();

        public Dictionary<string, GameObject> PreLoadObjects
        {
            get
            {
                return preloadPrefabs;
            }
        }

        List<IResourceLocation> locations = new List<IResourceLocation>();
        public Action OnDoneLoading;


        private async void Start()
        {
            await InitAndWaitUntilLoaded(Define.Addressable_ObjectPool_Label);

        }

        private async Task InitAndWaitUntilLoaded(string label)
        {
            await AddressableLocationLoader.GetAll(label, locations);

            foreach(var location in locations)
            {
                await LoadingGameObject(location.PrimaryKey);
                Debug.Log(location.PrimaryKey + " is loaded");
            }

            Debug.Log("All Object is loaded");

        }

        public async Task LoadingGameObject(string primaryKey)
        {
            var progress = Addressables.LoadAssetAsync<GameObject>(primaryKey);
            GameObject rs = await progress.Task;
            PreLoadObjects.Add(primaryKey, rs);
        }

    }
}

