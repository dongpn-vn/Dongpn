using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Command;

public class MoveCommand : ICommand
{
    Transform moveObject;
    float _speed;
    Vector3 direction;
    Vector3 oldPosition;

    public MoveCommand(Transform obj, float speed, float input)
    {
        moveObject = obj;
        _speed = speed;
        oldPosition = obj.position;
        direction = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z+input) - oldPosition;
    }


    public void Execute()
    {
        moveObject.Translate(direction.normalized * _speed * Time.deltaTime);
    }
}
