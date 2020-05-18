using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollision : OVRGrabber
{
    public bool enableIsTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed) {
            GetComponent<MeshCollider>().isTrigger = false;
        }
        else {
            GetComponent<MeshCollider>().isTrigger = true;
        }
    }
}
