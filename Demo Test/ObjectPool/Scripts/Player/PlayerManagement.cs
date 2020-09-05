using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.ObjectPool;

public class PlayerManagement : MonoBehaviour
{
    private PlayerHealth ph;
    private PlayerMovement pm;

    [SerializeField]
    private Transform bulletSpawnPos, gun;

    // Start is called before the first frame update
    void Start()
    {
        ph = GetComponent<PlayerHealth>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //spawm bullet
            SpawnBullet();
        }
    }

    public void SpawnBullet()
    {
        //Bullet b = ObjectsPoolManager.Instance.RequestObject<Bullet>();
        //b.SetOwner(this);
        //b.transform.position = bulletSpawnPos.position;
        //b.SetDirection(bulletSpawnPos.position - gun.position);
        //b.ObjectActive();
        BulletFireCommand bf = new BulletFireCommand(this, bulletSpawnPos.position, bulletSpawnPos.position - gun.position);
        bf.Execute();
    }
}
