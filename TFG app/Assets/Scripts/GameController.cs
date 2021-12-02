using RestClient.Core.Singletons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    GameData gameData;


    protected override void Awake()
    {
        gameData = DataAccess.Load();
        if (gameData == null)
        {
            gameData = new GameData();
        }
    }

    public void CompletarNivel(string nivel, int estrellas)
    {
        try
        {
        gameData.levels.Add(nivel, estrellas);
        }
        catch(ArgumentException)
        {
            gameData.levels.Remove(nivel);
            gameData.levels.Add(nivel, estrellas);
        }
    }

    public int ComprobarNivel(string nivel)
    {
        if (gameData != null)
        {
            try
            {
                return gameData.levels[nivel];
            }
            catch(KeyNotFoundException)
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    //testing
    public void ResetearNiveles()
    {
        gameData.levels = new Dictionary<string, int>();
    }

    public void GuardarProgreso()
    {
        DataAccess.Save(gameData);
    }
}
