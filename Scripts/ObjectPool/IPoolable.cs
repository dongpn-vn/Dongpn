using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Dongpn.ObjectPool
{
    public interface IPoolable
    { 
        int Index { get; set; }

        bool Avaiable
        {
            get;
        }

        void ObjectActive();

        void ObjectDeactive();

    }

}
