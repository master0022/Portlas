using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public GameObject linkedPortal;
    public Camera playerCamera;
    public GameObject portal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.transform.position - linkedPortal.transform.position;
        transform.position = portal.transform.position + playerOffsetFromPortal;
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.transform.rotation, linkedPortal.transform.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameradir = portalRotationalDifference * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameradir, Vector3.up);
    
    }
}
