using System.Collections;
using UnityEngine;
using Dongpn.ObjectPool;

public class LargePoolBullet : LargePoolItem
{
    private Rigidbody rg;
    private Transform tf;
    private float up = 1.0f;
    private float side = 0.1f;
    private Vector3 spawnPostion = new Vector3(0,2,0);

    void OnEnable()
    {
        rg = GetComponent<Rigidbody>();
        tf = transform;
    }

    private void Fire()
    {
        float x = Random.Range(-side, side);
        float y = Random.Range(up/2, up);
        float z = Random.Range(-side, side);

        rg.velocity = new Vector3(x,y,z);
    }

    public override void ObjectActive()
    {
        gameObject.SetActive(true);
        tf.position = spawnPostion;
        Fire();

    }

    public override void ObjectDeactive()
    {
        gameObject.SetActive(false);
        BulletPoolManager.Instance.ObjectRecycle(Index);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag: "+other.tag);
        if(other.tag == "Respawn")
        {
            ObjectDeactive();
        }
    }
}
