using System.Collections;
using UnityEngine;
using Dongpn.ObjectPool;

[PrefabsFactory("Sphere")]
public class Bullet : MonoBehaviour, IPoolable
{
    private bool state = true;
    public bool Avaiable
    {
        get => state;
    }

    private int index = -1;

    public int Index
    {
        get => index;
        set => index = value;
    }

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

    public void ObjectActive()
    {
        //Debug.Log("Active Object");
        gameObject.SetActive(true);
        state = false;
        Fire();
        StartCoroutine(IEActiveObjects());
    }

    public void ObjectDeactive()
    {
        state = true;
        //Debug.Log("Deactive Object");
        gameObject.SetActive(false);
        //BulletPoolManager.Instance.ObjectRecycle(index);
    }

    IEnumerator IEActiveObjects()
    {
        //Debug.Log("Start");
        float time = Random.Range(1.0f, 10.0f);
        yield return new WaitForSeconds(time);
        //Debug.Log(string.Format("After {0}s, deactive",time));
        ObjectDeactive();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Debug.Log("hit " + collision.gameObject.name);
            HitObjects(collision.gameObject);
        }
    }

    private void HitObjects(GameObject hit)
    {
        PlayerHealth ph = hit.GetComponent<PlayerHealth>();
        if (ph!=null)
        {
            if(!ph.IsDead)
            {
                ph.TakeDamage(20);
                if(ph.IsDead)
                {
                    new KillEvent(owner.gameObject, hit).Trigger();
                }
            }
        }
        ObjectDeactive();
    }

}
