using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Difficulty dificultad;
    public int nivel;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite starEmpty;
    public Sprite starFull;    


    public void Start()
    {
        string nivelString = dificultad.ToString() + nivel.ToString();
        
        switch(GameController.Instance.comprobarNivel(nivelString))
        {
            case 1:
                star1.sprite = starFull;
                star2.sprite = starEmpty;
                star3.sprite = starEmpty;
                break;

            case 2:
                star1.sprite = starFull;
                star2.sprite = starFull;
                star3.sprite = starEmpty;
                break;

            case 3:
                star1.sprite = starFull;
                star2.sprite = starFull;
                star3.sprite = starFull;
                break;

            default:
                star1.sprite = starEmpty;
                star2.sprite = starEmpty;
                star3.sprite = starEmpty;
                break;
        }
    }

    public void StartLevel()
    {
        SceneLoader.Instance.SwitchLevel(dificultad, nivel);
    }

    

}
