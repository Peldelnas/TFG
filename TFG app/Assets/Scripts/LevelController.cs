using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    // azureFacesResponse.result[0].faceAttributes.emotion.anger.ToString();
    public Difficulty difficulty;
    public int nivel;
    public double angerMin1;
    public double contemptMin1;
    public double disgustMin1;
    public double fearMin1;
    public double happinessMin1;
    public double neutralMin1;
    public double sadnessMin1;
    public double surpriseMin1;
    public double angerMin2;
    public double contemptMin2;
    public double disgustMin2;
    public double fearMin2;
    public double happinessMin2;
    public double neutralMin2;
    public double sadnessMin2;
    public double surpriseMin2;
    public double angerMin3;
    public double contemptMin3;
    public double disgustMin3;
    public double fearMin3;
    public double happinessMin3;
    public double neutralMin3;
    public double sadnessMin3;
    public double surpriseMin3;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Sprite starEmpty;
    public Sprite starFull;
    public Sprite transparent;
    public GameObject imageDef;

    public GameObject star1Ending;
    public GameObject star2Ending;
    public GameObject star3Ending;

    public CameraScript cameraScript;
    public GameObject VictoryPanel;
    public GameObject ErrorPanel;

    int stage = 1;
    int score = 0;
    Image spriteDef;

    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        star1.GetComponent<Image>().sprite = transparent;
        star2.GetComponent<Image>().sprite = transparent;
        star3.GetComponent<Image>().sprite = transparent;

        star1Ending.GetComponent<Image>().sprite = transparent;
        star2Ending.GetComponent<Image>().sprite = transparent;
        star3Ending.GetComponent<Image>().sprite = transparent;

        spriteDef = imageDef.GetComponent<Image>();
        spriteDef.sprite = image1;
    }

    

    public void CompareResults(AzureFacesResponse response)
    {
        bool success = true;
        //hardcoded

        try
        {
            if (stage == 1)
            {
                if (angerMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < angerMin1)
                    {
                        success = false;
                    }
                }
                if (contemptMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < contemptMin1)
                    {
                        success = false;
                    }
                }
                if (disgustMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.disgust < disgustMin1)
                    {
                        success = false;
                    }
                }
                if (fearMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.fear < fearMin1)
                    {
                        success = false;
                    }
                }
                if (happinessMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.happiness < happinessMin1)
                    {
                        success = false;
                    }
                }
                if (neutralMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.neutral < neutralMin1)
                    {
                        success = false;
                    }
                }
                if (sadnessMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.sadness < sadnessMin1)
                    {
                        success = false;
                    }
                }
                if (surpriseMin1 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.surprise < surpriseMin1)
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    score++;
                    star1.GetComponent<Image>().sprite = starFull;
                }
                else
                {
                    star1.GetComponent<Image>().sprite = starEmpty;
                }
                spriteDef.sprite = image2;
            }

            if (stage == 2)
            {
                if (angerMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < angerMin2)
                    {
                        success = false;
                    }
                }
                if (contemptMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < contemptMin2)
                    {
                        success = false;
                    }
                }
                if (disgustMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.disgust < disgustMin2)
                    {
                        success = false;
                    }
                }
                if (fearMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.fear < fearMin2)
                    {
                        success = false;
                    }
                }
                if (happinessMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.happiness < happinessMin2)
                    {
                        success = false;
                    }
                }
                if (neutralMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.neutral < neutralMin2)
                    {
                        success = false;
                    }
                }
                if (sadnessMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.sadness < sadnessMin2)
                    {
                        success = false;
                    }
                }
                if (surpriseMin2 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.surprise < surpriseMin2)
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    score++;
                    star2.GetComponent<Image>().sprite = starFull;
                }
                else
                {
                    star2.GetComponent<Image>().sprite = starEmpty;
                }
                spriteDef.sprite = image3;
            }

            if (stage == 3)
            {
                if (angerMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < angerMin3)
                    {
                        success = false;
                    }
                }
                if (contemptMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.anger < contemptMin3)
                    {
                        success = false;
                    }
                }
                if (disgustMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.disgust < disgustMin3)
                    {
                        success = false;
                    }
                }
                if (fearMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.fear < fearMin3)
                    {
                        success = false;
                    }
                }
                if (happinessMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.happiness < happinessMin3)
                    {
                        success = false;
                    }
                }
                if (neutralMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.neutral < neutralMin3)
                    {
                        success = false;
                    }
                }
                if (sadnessMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.sadness < sadnessMin3)
                    {
                        success = false;
                    }
                }
                if (surpriseMin3 > 0)
                {
                    if (response.result[0].faceAttributes.emotion.surprise < surpriseMin3)
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    score++;
                    star3.GetComponent<Image>().sprite = starFull;
                    FinalizarNivel();
                }
                else
                {
                    star3.GetComponent<Image>().sprite = starEmpty;
                    FinalizarNivel();
                }
            }
            stage++;
        }
        
        catch (IndexOutOfRangeException)
        {
            ErrorPanel.SetActive(true);
            Text ErrorText = ErrorPanel.GetComponentsInChildren<Text>()[0];
            ErrorText.text = "¡Cuidado! No se ha podido detectar una cara en la imagen.";
        }
        
        
    }

    public void ReturnToMainMenu()
    {
        cameraScript.StopWebcam();
        SceneLoader.Instance.returnMainMenu();
    }
    public void RestartLevel()
    {
        cameraScript.StopWebcam();
        SceneManager.LoadScene(difficulty.ToString() + nivel.ToString());
    }

    public void FinalizarNivel()
    {
        if (score > 0)
        {
            star1Ending.GetComponent<Image>().sprite = starFull;            
        }
        else
        {
            star1Ending.GetComponent<Image>().sprite = starEmpty;
        }
        if (score > 1)
        {
            star2Ending.GetComponent<Image>().sprite = starFull;
        }
        else
        {
            star2Ending.GetComponent<Image>().sprite = starEmpty;
        }
        
        if (score > 2)
        {
            star3Ending.GetComponent<Image>().sprite = starFull;
        }
        else
        {
            star3Ending.GetComponent<Image>().sprite = starEmpty;
        }
        VictoryPanel.SetActive(true);
        string nivelCompletado = difficulty.ToString() + nivel.ToString();
        GameController.Instance.CompletarNivel(nivelCompletado, score);
        GameController.Instance.GuardarProgreso();
        
    }
}
