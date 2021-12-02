using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RestClient.Core;
using RestClient.Core.Models;
using TMPro;
using UnityEngine;

//borrar ui
using UnityEngine.UI;

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

    //borrar
    public GameObject ErrorPanel;


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

            //borrar y ver mejor forma
            ErrorPanel.SetActive(true);
            Text ErrorText = ErrorPanel.GetComponentsInChildren<Text>()[0];
            String text = "anger: " + azureFacesResponse.result[0].faceAttributes.emotion.anger.ToString();
            text += " contempt: " + azureFacesResponse.result[0].faceAttributes.emotion.contempt.ToString();
            text += " disgust: " + azureFacesResponse.result[0].faceAttributes.emotion.disgust.ToString();
            text += " fear: " + azureFacesResponse.result[0].faceAttributes.emotion.fear.ToString();
            text += " happiness: " + azureFacesResponse.result[0].faceAttributes.emotion.happiness.ToString();
            text += " neutral: " + azureFacesResponse.result[0].faceAttributes.emotion.neutral.ToString();
            text += " sadness: " + azureFacesResponse.result[0].faceAttributes.emotion.sadness.ToString();
            text += " surprise: " + azureFacesResponse.result[0].faceAttributes.emotion.surprise.ToString();

            ErrorText.text = text;
            

        }
    }

    public class ImageUrl
    {
        public string Url;
    }

    
}
