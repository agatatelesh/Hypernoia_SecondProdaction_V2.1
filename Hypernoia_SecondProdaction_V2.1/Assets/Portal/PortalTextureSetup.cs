using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera camera2;
    public Material cameraMatRoom2;
    // Start is called before the first frame update
    void Start()
    {
        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatRoom2.mainTexture = camera2.targetTexture;
        
    }

    

}
