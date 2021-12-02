using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public Dictionary<string, int> levels;

    public GameData()
    {
        levels = new Dictionary<string, int>();
    }

}
