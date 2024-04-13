using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cogerMaiz : MonoBehaviour
{
    public int granos = 0;
    public GameObject texto;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("pickableItem")){
            granos++;
            TextMeshProUGUI textoGUI = texto.GetComponent<TextMeshProUGUI>();
            textoGUI.text = $"Maíz: {granos}";
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("bread")){
            SceneManager.LoadScene("Victoria");
        }
    }
}
