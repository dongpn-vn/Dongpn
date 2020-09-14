using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Singleton;
using System.Threading.Tasks;

namespace Dongpn.ObjectPool
{
    public class ObjectsPoolManager : Singleton<ObjectsPoolManager>
    {

        static Dictionary<string, List<SmallPoolItem>> poolDic = new Dictionary<string, List<SmallPoolItem>>();

        private static List<SmallPoolItem> GetList(string typeOf) 
        {
            if (poolDic.ContainsKey(typeOf))
            {
                return poolDic[typeOf];
            }
            else
            {
                List<SmallPoolItem> list = new List<SmallPoolItem>();
                poolDic[typeOf] = list;
                return list;
            }
        }

        public T RequestObject<T>() where T : SmallPoolItem
        {
            Debug.Log("Request Objects");
            List<SmallPoolItem> list = GetList(typeof(T).Name);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Avaiable)
                {
                    return (T) list[i];
                }
            }

            T next_object = GetNewInstance<T>();
            list.Add(next_object);
            return next_object;
        }

        private T GetNewInstance<T>() where T : SmallPoolItem
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(typeof(T));

            foreach (System.Attribute attr in attrs)
            {
                if (attr is PrefabsFactory)
                {
                    PrefabsFactory pF = (PrefabsFactory)attr;
                    if(ObjectsLibrary.Instance.PreLoadObjects.ContainsKey(pF.PrimaryKey))
                    {
                        return Instantiate(ObjectsLibrary.Instance.PreLoadObjects[pF.PrimaryKey]).AddComponent<T>();
                    }                    
                }
            }
            return new GameObject(typeof(T).Name).AddComponent<T>();
        }

    }

}
