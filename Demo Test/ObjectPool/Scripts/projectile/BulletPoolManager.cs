using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.ObjectPool;

public class BulletPoolManager : ObjectPool<Bullet>
{
    private static BulletPoolManager instance;
    public static BulletPoolManager Instance
    {
        get
        {
            if(instance==null)
            {
                Debug.Log("instance null");
            }
            return instance;
        }

        protected set => instance = value;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
