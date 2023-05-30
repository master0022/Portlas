using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    public Portal linkedPortal;

    public MeshRenderer thisRenderer;
    public Camera thisCamera;

    public Camera playerCamera;


    private RenderTexture viewTexture;
    void Start()
    {
        playerCamera = Camera.main;
        

        SetupTexture();
    }

    void SetupTexture()
    {
        if (viewTexture == null || viewTexture.width != UnityEngine.Screen.width || viewTexture.height != UnityEngine.Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(UnityEngine.Screen.width, UnityEngine.Screen.height, 0);
            // Render the view from the portal camera to the view texture
            thisCamera.targetTexture = viewTexture;
            // Display the view texture on the screen of the linked portal
            thisRenderer.material.SetTexture("_MainTex", viewTexture);
        }
        
    }

    void MoveCamera()
    {

        thisCamera.transform.position = this.transform.position + linkedPortal.transform.position - playerCamera.transform.position;
        thisCamera.transform.forward = (this.transform.position - playerCamera.transform.position).normalized * -1f;
        thisCamera.Render();
    }

    // Update is called once per frame
    void Update()
    {
        
        SetupTexture();
        linkedPortal.thisRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        linkedPortal.thisRenderer.material.SetInt("displayMask", 0);
        thisRenderer.material.SetInt("displayMask", 0);
        thisRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        MoveCamera();
        linkedPortal.thisRenderer.material.SetInt("displayMask", 1);
        linkedPortal.thisRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        thisRenderer.material.SetInt("displayMask", 0);
        thisRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }
}
