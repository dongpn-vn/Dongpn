using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Dongpn.Addressable
{
    public static class AddressableLocationLoader
    {

        public static async Task GetAll(string label, IList<IResourceLocation> loadedLocations)
        {
            var unloadedLocations = await Addressables.LoadResourceLocationsAsync(label).Task;

            foreach (var location in unloadedLocations)
                loadedLocations.Add(location);
        }

        public static List<string> GetLabels()
        {
            AddressableAssetSettings settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            object labelTable = settings.GetType().GetProperty("labelTable", bindingFlags).GetValue(settings);
            List<string> labelNames = (List<string>)labelTable.GetType().GetProperty("labelNames", bindingFlags).GetValue(labelTable);

            return labelNames;
        }
    }
}

