using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 destination;
    private Rigidbody rg;

    public float speed = 5f;
    public float r_speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        if (z <= -0.1f || z >= 0.1f)
        {
            //Vector3 current = transform.position;
            //Vector3 destination = new Vector3(current.x, current.y, current.z + z);
            //Vector3 direction = destination - transform.position;
            //transform.Translate(direction.normalized * speed * Time.deltaTime);
            MoveCommand move = new MoveCommand(transform, speed, z);
            move.Execute();
        }

        //if(x >= 0.1f)
        //{
        //    transform.Rotate(new Vector3(0, 1, 0) * r_speed/60f, Space.World);
        //}

        //if (x <= -0.1f)
        //{
        //    transform.Rotate(new Vector3(0, -1, 0) * r_speed/60f, Space.World);
        //}
        if (x <= -0.1f || x >= 0.1f)
        {
            RotateCommand rotate = new RotateCommand(transform, r_speed,x);
            rotate.Execute();
        }
    }
}
