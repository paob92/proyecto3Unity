using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//para saber posición de imagen
    private float repeatWidth;//para repetir el ancho 
    void Start()
    {
        startPos = transform.position;//para copiar el fondo y que se genere solo
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;//se divide en 2 para encontrar la mitad de la imagen
    }

    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)// para que se repita de nueva la imagen de fondo
        {
            transform.position = startPos;
        }
    }
}
