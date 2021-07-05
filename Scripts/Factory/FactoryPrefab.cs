using System;
using System.Reflection;
using UnityEngine;

namespace Dongpn.Factory
{
    public abstract class FactoryPrefab<T> : MonoBehaviour where T : FactoryPrefab<T>
    {
        public static T GetInstance()
        {
            PrefabsFactory att = (PrefabsFactory)Attribute.GetCustomAttribute(typeof(T), typeof(PrefabsFactory));

            if (att == null || string.IsNullOrEmpty(att.PrimaryKey))
            {
                return new GameObject(typeof(T).Name).AddComponent<T>();
            }
            else
            {
                var prefabs = Resources.Load<GameObject>(att.PrimaryKey);
                GameObject go = Instantiate(prefabs);
                T rt = go.GetComponent<T>();

                return rt == null ? go.AddComponent<T>() : rt;
            }
        }
    }
}

