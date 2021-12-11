using RestClient.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CanvasType
{
    MainMenu,
    FacilMenu,
    MedioMenu,
    DificilMenu,
    SettingsMenu,
    InfoMenu
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    List<LevelSelector> levelSelectorList;
    protected override void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);

       

    }
   
    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
           
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;


            //horrible refactorizar YAAAAAAAAAAAAA
            levelSelectorList = new List<LevelSelector>();
            GameObject[] buttons;
            buttons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject obj in buttons)
            {
                levelSelectorList.Add(obj.GetComponent<LevelSelector>());
            }
            levelSelectorList.ForEach(x => x.UpdateLevel());
        }
        else { Debug.LogWarning("El canvas seleccionado no ha podido encontrarse"); }
    }
}
