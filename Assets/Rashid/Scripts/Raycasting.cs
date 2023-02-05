using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public Transform RayOrigin;
    Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(RayOrigin.position, RayOrigin.TransformDirection(Vector3.forward), out hit,50,layerMask))
        {
            if (hit.transform.tag.Contains("Enemy"))
                Debug.DrawRay(RayOrigin.position, RayOrigin.TransformDirection(Vector3.forward) * 50, Color.green);
            else if(hit.transform.tag.Contains("Ground"))
                Debug.DrawRay(RayOrigin.position, RayOrigin.TransformDirection(Vector3.forward) * 50, Color.yellow);
        }
        else
        {
            Debug.DrawRay(RayOrigin.position, RayOrigin.TransformDirection(Vector3.forward) * 50, Color.red);
        }

    }
}
