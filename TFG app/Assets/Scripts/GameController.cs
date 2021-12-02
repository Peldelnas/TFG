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

    public void completarNivel(string nivel, int estrellas)
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

    public int comprobarNivel(string nivel)
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
    public void resetearNiveles()
    {
        gameData.levels = new Dictionary<string, int>();
    }

    public void guardarProgreso()
    {
        DataAccess.Save(gameData);
    }
}
