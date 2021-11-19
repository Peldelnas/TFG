using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{

    int currentCamIndex = 0;
    
    WebCamTexture tex;

    public RawImage display;
    public GameObject ErrorPanel;
    public GameObject PhotoButton;

    public Text startStopText;

    public void SwapCam_Clicked() {
        ErrorPanel.SetActive(false);        
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
            

            if (tex != null) //por si hay alguna c�mara activa
            {
                
                StopWebcam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked() {
    try
        {
        if (tex != null) // Apagar c�mara
        {
            StopWebcam();
            startStopText.text = "Encender c�mara";
        }
        else // encender c�mara
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            
            tex.Play();
            PhotoButton.SetActive(true);
            startStopText.text = "Apagar c�mara";

        }
        } 
        catch(IndexOutOfRangeException) //Por si no detecta c�maras
        {            
            ErrorPanel.SetActive(true);
            Text ErrorText = ErrorPanel.GetComponentsInChildren<Text>()[0];           
            ErrorText.text = "Error! No se ha podido detectar la c�mara";

        }        
    }

    private void StopWebcam() 
    {
        display.texture = null;
        tex.Stop();
        tex = null;
        PhotoButton.SetActive(false);
    }

    public void TakePhoto_Clicked()
    {
        Texture2D texture = new Texture2D(display.texture.width, display.texture.height, TextureFormat.ARGB32, false);
        texture.SetPixels(tex.GetPixels());
        texture.Apply();
        byte[] bytes = texture.EncodeToPNG();        
        File.WriteAllBytes(Application.dataPath + "/images/testimg.png", bytes);
        StopWebcam();
    }
}
