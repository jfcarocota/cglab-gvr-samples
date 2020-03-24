using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 100f)]
    float rayDistance;
    [SerializeField]
    LayerMask layer;
    RaycastHit hit;

    [SerializeField]
    Transform reticle;
    [SerializeField]
    Vector3 startSize;
    [SerializeField]
    float error;

    VRButton vrButton;

    void Start()
    {
        startSize = reticle.localScale;
    }
    
    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layer))
        {
            //Debug.Log("hit");
            //Debug.Log($"distance:{hit.distance}");
            //Debug.Log($"hit point:{hit.point}");
            //Debug.Log($"normal: {hit.normal}");
            
            reticle.localScale = startSize * error * hit.distance;
            reticle.position = hit.point + new Vector3(0, 0, -0.01f);
            reticle.localRotation = Quaternion.LookRotation(hit.normal);

            vrButton = hit.collider.GetComponent<VRButton>();
            if(vrButton && Input.GetMouseButtonDown(0))
            {
                vrButton.Click();
            }
        }
        else
        {
            reticle.localPosition = Vector3.zero;
            reticle.localRotation = Quaternion.identity;
            reticle.localScale = startSize;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
