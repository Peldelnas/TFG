using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void doExitGame()
    {
        GameController.Instance.GuardarProgreso();
        Application.Quit();
    }
    
}
