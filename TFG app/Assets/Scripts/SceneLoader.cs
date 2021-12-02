using RestClient.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty
{
    Facil,
    Medio,
    Dificil
}

public class SceneLoader : Singleton<SceneLoader>
{

    public void SwitchLevel(Difficulty difficulty, int level)
    {
        SceneManager.LoadScene(difficulty.ToString() + level.ToString());        
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
