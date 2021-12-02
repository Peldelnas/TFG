using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public Difficulty dificultad;
    public int nivel;
    
    public void StartLevel()
    {
        SceneLoader.Instance.SwitchLevel(dificultad, nivel);
    }

}
