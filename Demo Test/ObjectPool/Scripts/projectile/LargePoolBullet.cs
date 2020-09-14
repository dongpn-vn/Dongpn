using System.Collections;
using UnityEngine;
using Dongpn.ObjectPool;

public class LargePoolBullet : LargePoolItem
{
    private Rigidbody rg;
    private float speed = 10f;
    private Vector3 _direction;

    private PlayerManagement owner;

    void OnEnable()
    {
        rg = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetOwner(PlayerManagement pm)
    {
        owner = pm;
        Physics.IgnoreCollision(pm.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void Fire()
    {
        rg.velocity = _direction.normalized * speed;
    }

    public override void ObjectActive()
    {
        //base.ObjectActive();
        //Debug.Log("Active Object");
        gameObject.SetActive(true);
        //Fire();
        StartCoroutine(IEActiveObjects());
    }

    public override void ObjectDeactive()
    {
        //Debug.Log("Deactive Object");
        gameObject.SetActive(false);
        BulletPoolManager.Instance.ObjectRecycle(Index);
        //base.ObjectDeactive();
    }

    IEnumerator IEActiveObjects()
    {
        //Debug.Log("Start");
        float time = Random.Range(1.0f, 10.0f);
        yield return new WaitForSeconds(time);
        //Debug.Log(string.Format("After {0}s, deactive",time));
        ObjectDeactive();
    }
}
