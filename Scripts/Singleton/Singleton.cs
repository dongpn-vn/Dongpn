using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dongpn.Singleton
{

    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                //if (instance == null)
                //{
                //    instance = new GameObject(typeof(T).Name).AddComponent<T>();
                //}
                return instance;
            }

            protected set => instance = value;
        }

        public static bool InstanceExists { get { return Instance != null; } }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = (T)this;
            }
        }


        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

    }
}