using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveCam : MonoBehaviour
{
    WebCamTexture webCamTexture = null;
    public RawImage image;


    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        foreach (var device in devices)
        {
            if (device.isFrontFacing)
            {
                webCamTexture = new WebCamTexture(device.name, Screen.width, Screen.height);
                image.texture = webCamTexture;
                webCamTexture.Play();
            }
        }

        if (webCamTexture == null)
        {
            webCamTexture = new WebCamTexture();
        }

    }

    private void Update()
    {

        /* float ratio = (float)webCamTexture.width / (float)webCamTexture.height;
         fit.aspectRatio = ratio;
        */

        float scaleY = webCamTexture.videoVerticallyMirrored ? .55f : -.55f;
        image.rectTransform.localScale = new Vector3(2.1f, scaleY, 1f);

        int orient = -webCamTexture.videoRotationAngle;
        image.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }


}
