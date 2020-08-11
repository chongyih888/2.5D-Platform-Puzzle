using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    //detect moving box
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Moving Box")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance: " + distance);

            //if distance is less than 0.05
            //stop!
            if(distance < 0.05f)
            {
                Rigidbody box = other.GetComponent<Rigidbody>();
                if(box != null)
                {
                    box.isKinematic = true;
                }
                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();

                if(renderer != null)
                {
                   renderer.material.color = Color.blue;
                }
               
                Destroy(this);
            }
        }
    }

    //when close to center
    //disable the box's rigidbody or set it kinematic
    //change color of pressure pad to Blue!

}
