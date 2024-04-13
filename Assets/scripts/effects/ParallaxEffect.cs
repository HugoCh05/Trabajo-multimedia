using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ParallaxEffect : MonoBehaviour
{
    public Vector3 escala = Vector3.one;

    private Vector3 posicionInicial;
    private Transform posicion;

    // Start is called before the first frame update
    void Start()
    {
        posicion = Camera.main.transform;
        posicionInicial = posicion.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camaraCambio = posicion.position - posicionInicial;
        transform.position = Vector3.Scale(camaraCambio, escala);
    }
}
