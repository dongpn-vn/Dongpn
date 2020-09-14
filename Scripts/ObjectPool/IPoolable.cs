using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Dongpn.ObjectPool
{
    public interface IPoolable
    { 

        void ObjectActive();

        void ObjectDeactive();

    }

}
