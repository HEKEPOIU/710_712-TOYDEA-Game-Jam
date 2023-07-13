using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlane : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)    
    {
        if (playerControl.IsCatchAble)
        {
            DropItem item = other.gameObject.GetComponent<DropItem>();
            item.CatchEffect();
        }
        Destroy(other.gameObject);
    }
}
