using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Command;

public class RotateCommand : ICommand
{
    Transform rotateObject;
    float rotateSpeed;
    Vector3 eulers;
    Vector3 oldRotate;

    public RotateCommand(Transform obj, float speed, float input)
    {
        rotateObject = obj;
        rotateSpeed = speed;
        oldRotate = obj.rotation.eulerAngles;

        //input always greater than 0.1f or less than -0.1f
        if (input > 0)
        {
            eulers = new Vector3(0, 1, 0);
        }
        else
        {
            eulers = new Vector3(0, -1, 0);
        }
    }

    public void Execute()
    {
        rotateObject.Rotate(eulers * rotateSpeed/60, Space.World);
    }
}
