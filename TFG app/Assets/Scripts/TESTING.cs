using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void completarNivel1()
    {
        GameController.Instance.completarNivel("Medio1", 3);
    }

    void ResetearNiveles()
    {
        GameController.Instance.resetearNiveles();
    }
}