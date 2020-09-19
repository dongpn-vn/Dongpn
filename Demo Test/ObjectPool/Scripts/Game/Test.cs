using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.ObjectPool;

public class Test : MonoBehaviour
{
    private bool isSpawn = false;

    private void Start()
    {
        ClickEvent.OnEventTrigger += (ev) => { if (ev.eventType == EventType.ClickEventType) { Debug.Log("Click on screen, call from object "+ev.obj.name); } };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isSpawn = !isSpawn;
        } 

        if(isSpawn)
        {
            for(int i = 0; i < 5; i++)
            {
                LargePoolBullet bullet = BulletPoolManager.Instance.RequestObject();
                bullet.ObjectActive();
            }
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            //click left button
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                    ClickEvent click = new ClickEvent(hit.transform.gameObject);
                    click.Trigger();        
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            //click right mouse
            //clear event
            ClickEvent.ClearListener();
        }
    }

}
