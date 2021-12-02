using RestClient.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    GameData gameData;


    protected override void Awake()
    {
        gameData = DataAccess.Load();
    }

    public void completarNivel(string nivel, int estrellas)
    {
        gameData.levels.Add(nivel, estrellas);
    }

    public int comprobarNivel(string nivel)
    {
        return gameData.levels[nivel];
    }

    //testing
    public void resetearNiveles()
    {
        gameData.levels = new Dictionary<string, int>();
    }
}
