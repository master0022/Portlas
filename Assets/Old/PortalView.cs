using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PortalView : MonoBehaviour
{
    public GameObject linkedPortal;

    public MeshRenderer screen;

    Camera playerCamera;
    public Camera portalCamera;
    RenderTexture portalRenderTexture;


    // Start is called before the first frame update
    void Start()
    {
        linkedPortal = this.transform.parent.GetComponentInChildren<Teleporter>().linkedportal;

        playerCamera = Camera.main;

        GameObject newcam = new GameObject();
        newcam.AddComponent<Camera>();
        PortalCamera pc = newcam.AddComponent<PortalCamera>();

        pc.playerCamera = playerCamera;
        pc.linkedPortal = linkedPortal;
        pc.portal = this.transform.parent.gameObject;
        newcam.transform.parent = linkedPortal.transform;

        portalCamera = newcam.GetComponent<Camera>();
        portalCamera = newcam.GetComponent<Camera>();


        portalRenderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        portalCamera.targetTexture = portalRenderTexture;

        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", portalRenderTexture);
    }

    void CreateViewTexture()
    {

    }


    void Update()
    {
        Vector3 a;
        Quaternion b;
        Vector3 aa;
        portalCamera.enabled = false;

        //playerCamera.transform.GetPositionAndRotation(out a,out b);
       // a = a - this.transform.position ;
        //linkedPortal.transform.GetLocalPositionAndRotation(out aa, out _);
        //portalCamera.transform.SetLocalPositionAndRotation(a-aa,b);
        
        //portalCamera.Render();

        portalCamera.transform.forward = (this.transform.position - playerCamera.transform.position).normalized * -1f;

        portalCamera.transform.position = this.transform.position - playerCamera.transform.position + linkedPortal.transform.position;
        portalCamera.enabled = true;
        portalCamera.Render();
    }



    
    
}
