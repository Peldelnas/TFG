using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//asegurar de que existan dependencias
//interfaces a implementar para recibir callbacks al entrar el ratón y salir
[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public CanvasType desiredCanvasType;

    CanvasManager canvasManager;
    Button button;
    Animator animator;
    

    private void Start()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();

        //cuando el evento se produce, se llaman a todas las funciones registradas como listeners
        button.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.Instance;
    }
    
    void OnButtonClicked()
    {
        
        canvasManager.SwitchCanvas(desiredCanvasType);        
        animator.SetBool("pressed", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("selected", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("selected", false);
        animator.SetBool("pressed", false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("pressed", true);
    }
}
