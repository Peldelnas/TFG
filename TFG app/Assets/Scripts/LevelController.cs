using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject PhotoButton;
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
    public Sprite negra;

    public GameObject imageDef;

    public GameObject star1Ending;
    public GameObject star2Ending;
    public GameObject star3Ending;

    public CameraScript cameraScript;
    public GameObject VictoryPanel;
    public GameObject ErrorPanel;

    public AudioSource successAudio;
    public AudioSource wrongAudio;
    public AudioSource tadaAudio;
    int stage = 1;
    int score = 0;
    Image spriteDef;

    public Sprite feedTrans;
    public Image feedFX;
    public Image feedImage;
    public Text feedText;
    public Sprite feedFXSprite;
    public Sprite angerS;
    public Sprite contemptS;
    public Sprite disgustS;
    public Sprite fearS;
    public Sprite happinessS;
    public Sprite neutralS;
    public Sprite sadnessS;
    public Sprite surpriseS;

    public Animator feedAnimator;

    private bool success = true;


    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        star1.GetComponent<Image>().sprite = starEmpty;
        star2.GetComponent<Image>().sprite = starEmpty;
        star3.GetComponent<Image>().sprite = starEmpty;

        star1Ending.GetComponent<Image>().sprite = starEmpty;
        star2Ending.GetComponent<Image>().sprite = starEmpty;
        star3Ending.GetComponent<Image>().sprite = starEmpty;

        spriteDef = imageDef.GetComponent<Image>();
        spriteDef.sprite = image1;

        feedImage.sprite = feedTrans;
        feedText.text = "";
        feedFX.sprite = feedTrans;

    }

    

    public void CompareResults(AzureFacesResponse response)
    {
        success = true;
        //hardcoded
        PhotoButton.SetActive(false);

        try
        {

            int indexFeed = 0;
            double maxFeed = 0;

            for (int it = 0; it < 2; it++)
            {
                if (response.result[0].faceAttributes.emotion.anger >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.anger;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = angerS;
                        feedText.text = "Enfado";
                    }


                }
                if (response.result[0].faceAttributes.emotion.contempt >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.contempt;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = contemptS;
                        feedText.text = "Desprecio";
                    }

                }

                if (response.result[0].faceAttributes.emotion.disgust >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.disgust;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = disgustS;
                        feedText.text = "Disgusto";
                    }

                }
                if (response.result[0].faceAttributes.emotion.fear >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.fear;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = fearS;
                        feedText.text = "Miedo";
                    }

                }
                if (response.result[0].faceAttributes.emotion.happiness >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.happiness;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = happinessS;
                        feedText.text = "Felicidad";
                    }

                }
                if (response.result[0].faceAttributes.emotion.neutral >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.neutral;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = neutralS;
                        feedText.text = "Neutro";
                    }

                }
                if (response.result[0].faceAttributes.emotion.sadness >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.sadness;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = sadnessS;
                        feedText.text = "Tristeza";
                    }

                }
                if (response.result[0].faceAttributes.emotion.surprise >= maxFeed)
                {
                    if (it == 0)
                    {
                        maxFeed = response.result[0].faceAttributes.emotion.surprise;
                    }
                    if (it == 1)
                    {
                        feedImage.sprite = surpriseS;
                        feedText.text = "Sorpresa";
                    }

                }


            }


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
                    if (response.result[0].faceAttributes.emotion.contempt < contemptMin1)
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
                StartCoroutine("WaitFeed",stage);
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
                    if (response.result[0].faceAttributes.emotion.contempt < contemptMin2)
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
                StartCoroutine("WaitFeed", stage);
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
                    if (response.result[0].faceAttributes.emotion.contempt < contemptMin3)
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
                StartCoroutine("WaitFeed", stage);
                
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        feedImage.sprite = feedTrans;
        feedText.text = "";
        if (score > 0)
        {
            star1Ending.GetComponent<Image>().sprite = starFull;
            tadaAudio.Play();
        }
        else
        {
            star1Ending.GetComponent<Image>().sprite = starEmpty;
            wrongAudio.Play();
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

    IEnumerator WaitFeed(int stageN)
    {
        
        if (stageN == 1)
        {
            feedFX.sprite = feedFXSprite;
            feedAnimator.Play("feedback_iddle", -1);
            yield return new WaitForSeconds(0.5f);
            feedAnimator.Play("feedback_quieto", -1);
            yield return new WaitForSeconds(1.0f);
            if (success)
            {
                score++;
                star1.GetComponent<Image>().sprite = starFull;
                successAudio.Play();
            }
            else
            {
                wrongAudio.Play();
                star1.GetComponent<Image>().sprite = negra;
            }
            spriteDef.sprite = image2;
            feedImage.sprite = feedTrans;
            feedText.text = "";
            feedFX.sprite = feedTrans;
        }
        if (stageN == 2)
        {
            feedFX.sprite = feedFXSprite;
            feedAnimator.Play("feedback_iddle", -1);
            yield return new WaitForSeconds(0.5f);
            feedAnimator.Play("feedback_quieto", -1);
            yield return new WaitForSeconds(1.0f);
            if (success)
            {
                score++;
                star2.GetComponent<Image>().sprite = starFull;
                successAudio.Play();
            }
            else
            {
                wrongAudio.Play();
                star2.GetComponent<Image>().sprite = negra;
            }
            spriteDef.sprite = image3;
            feedImage.sprite = feedTrans;
            feedText.text = "";
            feedFX.sprite = feedTrans;
        }
        if (stageN == 3)
        {
            feedFX.sprite = feedFXSprite;
            feedAnimator.Play("feedback_iddle", -1);
            yield return new WaitForSeconds(0.5f);
            feedAnimator.Play("feedback_quieto", -1);
            yield return new WaitForSeconds(1.0f);
            if (success)
            {
                score++;
                star3.GetComponent<Image>().sprite = starFull;
                successAudio.Play();
                StartCoroutine(Wait());
            }
            else
            {
                star3.GetComponent<Image>().sprite = negra;
                wrongAudio.Play();
                StartCoroutine(Wait());
            }
            spriteDef.sprite = image2;
            feedImage.sprite = feedTrans;
            feedText.text = "";
            feedFX.sprite = feedTrans;
        }
        PhotoButton.SetActive(true);
    }
    public void FinalizarNivel()
    {        
        if (score > 0)
        {
            star1Ending.GetComponent<Image>().sprite = starFull;
            tadaAudio.Play();
        }
        else
        {
            star1Ending.GetComponent<Image>().sprite = starEmpty;
            wrongAudio.Play();
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
