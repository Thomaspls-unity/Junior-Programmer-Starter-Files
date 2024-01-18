using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float interactionDistance;

    private IGrabbable grabbable;
    private RaycastHit hit;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            grabbable = hit.collider.GetComponent<IGrabbable>();

            if (grabbable != null) //if we find the IGrabbbable component on the object we hit
            {
                grabbable.OnHoverEnter();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    grabbable.OnGrab(grabPoint);
                }
            }
        }
        else
        {
            if (grabbable != null)
            {
                grabbable.OnHoverExit();
                grabbable = null;
            }
        }
        Debug.DrawRay(transform.position, transform.forward * interactionDistance);
    }
}
