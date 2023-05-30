using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalScreen : MonoBehaviour
{
    public GameObject linkedPortal;
    Camera portalCamera;
    Camera playercam;
    RenderTexture portalRenderTexture;
    public MeshRenderer screen;
    // Start is called before the first frame update
    void Start()
    {
        playercam = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();

        portalCamera = GetComponentInChildren<Camera>();
        
        
        portalRenderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        portalCamera.targetTexture = portalRenderTexture;
        screen.material.SetTexture("_MainTex", portalRenderTexture);
        //screen.material.SetInteger("displayMask", 1);
    }

    // Update is called once per frame
    void Update()
    {

        RenderTexture viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
        // Render the view from the portal camera to the view texture
        portalCamera.targetTexture = viewTexture;
        // Display the view texture on the screen of the linked portal
        screen.material.SetTexture("_MainTex", viewTexture);

        portalCamera.transform.forward = (this.transform.position - playercam.transform.position).normalized*-1f;

        portalCamera.transform.position = this.transform.position - playercam.transform.position +linkedPortal.transform.position ;

        portalCamera.Render();
    }
}
