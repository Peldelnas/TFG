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

    //[SerializeField]
    //private string imageToFaces = "";

    private RequestHeader clientSecurityHeader;
    private RequestHeader contentTypeHeader;

    //borrar
    public GameObject ErrorPanel;
    public LevelController levelController;

    public GameObject Loading;


    void Start()
    {
        Loading.SetActive(false);
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
    }

    public void SendPhoto(byte[] photo)
    {
        Loading.SetActive(true);
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

        Loading.SetActive(false);
        //aquí vemos el response
        if (string.IsNullOrEmpty(response.Error) && !string.IsNullOrEmpty(response.Data))
        {
            //pequeño fix para que no se queje del array
            string data = "{\"result\":" + response.Data.ToString() + "}";
            AzureFacesResponse azureFacesResponse = JsonUtility.FromJson<AzureFacesResponse>(data);

            levelController.CompareResults(azureFacesResponse);








            String text = "anger: " + azureFacesResponse.result[0].faceAttributes.emotion.anger.ToString();
            text += " contempt: " + azureFacesResponse.result[0].faceAttributes.emotion.contempt.ToString();
            text += " disgust: " + azureFacesResponse.result[0].faceAttributes.emotion.disgust.ToString();
            text += " fear: " + azureFacesResponse.result[0].faceAttributes.emotion.fear.ToString();
            text += " happiness: " + azureFacesResponse.result[0].faceAttributes.emotion.happiness.ToString();
            text += " neutral: " + azureFacesResponse.result[0].faceAttributes.emotion.neutral.ToString();
            text += " sadness: " + azureFacesResponse.result[0].faceAttributes.emotion.sadness.ToString();
            text += " surprise: " + azureFacesResponse.result[0].faceAttributes.emotion.surprise.ToString();

            Debug.Log(text);
            

        }
    }

 

    
}
