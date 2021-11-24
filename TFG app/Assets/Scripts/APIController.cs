using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RestClient.Core;
using RestClient.Core.Models;
using TMPro;
using UnityEngine;

public class APIController : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceAttributes=smile,emotion";

    [SerializeField]
    private string clientId;

    [SerializeField]
    private string clientSecret;

    [SerializeField]
    private string imageToFaces = "";

    private RequestHeader clientSecurityHeader;
    private RequestHeader contentTypeHeader;


    void Start()
    {
        // setup the request header
        clientSecurityHeader = new RequestHeader
        {
            Key = clientId,
            Value = clientSecret
        };

        // setup the request header
        contentTypeHeader = new RequestHeader
        {
            //Key = "Content-Type",
            //Value = "application/json"
            Key = "Content-Type",
            Value = "application/octet-stream"

        };

        // validation
        //if (string.IsNullOrEmpty(imageToFaces))
        //{
        //    Debug.LogError("imageToOCR needs to be set through the inspector...");
        //    return;
        //}

        //// build image url required by Azure Vision Faces
        //ImageUrl imageUrl = new ImageUrl { Url = imageToFaces };

        //// send a post request

        //StartCoroutine(RestWebClient.Instance.HttpPost(baseUrl, JsonUtility.ToJson(imageUrl), (r) => OnRequestComplete(r), new List<RequestHeader>
        //{
        //    clientSecurityHeader,
        //    contentTypeHeader
        //}));
    }

    public void SendPhoto(byte[] photo)
    {      
        StartCoroutine(RestWebClient.Instance.HttpPostStream(baseUrl,photo , (r) => OnRequestComplete(r), new List<RequestHeader>
        {
            clientSecurityHeader,
            contentTypeHeader
        }));
    }

    void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

        //aquí vemos el response
        if (string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            //pequeño fix para que no se queje del array
            string data = "{\"result\":" + response.Data.ToString() + "}";
            AzureFacesResponse azureFacesResponse = JsonUtility.FromJson<AzureFacesResponse>(data);



            Debug.Log("breakpoint");


            /* header.text = $"Orientation: {azureFacesResponse.orientation} Language: {azureFacesResponse.language} Text Angle: {azureFacesResponse.textAngle}";

             string words = string.Empty;
             foreach (var region in azureFacesResponse.regions)
             {
                 foreach (var line in region.lines)
                 {
                     foreach (var word in line.words)
                     { 
                         words += word.text + "\n";
                     }
                 }
             } 
             wordsCapture.text = words; */
        }
    }

    public class ImageUrl
    {
        public string Url;
    }

    
}
