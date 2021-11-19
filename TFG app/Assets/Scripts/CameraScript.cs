using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{

    int currentCamIndex = 0;
    
    WebCamTexture tex;

    public RawImage display;
    public GameObject ErrorPanel;

    public Text startStopText;

    public void SwapCam_Clicked() {
        ErrorPanel.SetActive(false);
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
            

            if (tex != null)
            {
                
                StopWebcam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked() {
    try
        {
        if (tex != null) // Apagar cámara
        {
            StopWebcam();
            startStopText.text = "Encender cámara";
        }
        else // encender cámara
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            
            tex.Play();
            startStopText.text = "Apagar cámara";
        }
        } 
        catch(IndexOutOfRangeException)
        {            
            ErrorPanel.SetActive(true);
            Text ErrorText = ErrorPanel.GetComponentsInChildren<Text>()[0];           
            ErrorText.text = "Error! No se ha podido detectar la cámara";

        }        
    }

    private void StopWebcam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}
