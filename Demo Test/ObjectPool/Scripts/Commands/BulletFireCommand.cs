using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Command;
using Dongpn.ObjectPool;

public class BulletFireCommand : ICommand
{
    PlayerManagement owner;
    Vector3 position;
    Vector3 direction;

    public BulletFireCommand(PlayerManagement pm, Vector3 spawnPosition, Vector3 fireDirection)
    {
        owner = pm;
        position = spawnPosition;
        direction = fireDirection;
    }

    public void Execute()
    {
        Bullet b = ObjectsPoolManager.Instance.RequestObject<Bullet>();
        b.SetOwner(owner);
        b.transform.position = position;
        b.SetDirection(direction);
        b.ObjectActive();
    }
}
