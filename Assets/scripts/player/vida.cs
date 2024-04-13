using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vida : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    private int vidaTotal = 3;
    private Animator _animator1;
    private Animator _animator2;
    private Animator _animator3;
    private Animator _animator_pato;
    private bool hitting = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator1 = vida1.GetComponent<Animator>();
        _animator2 = vida2.GetComponent<Animator>();
        _animator3 = vida3.GetComponent<Animator>();
        _animator_pato = GetComponent<Animator>();
    }

    void Update(){
        if(hitting){
            hitting = false;
        }else{
            _animator_pato.SetBool("hit", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("enemy")){
            vidaTotal--;
            _animator_pato.SetBool("hit", true);
            hitting = true;

            switch(vidaTotal){
                case 2:
                    _animator3.SetBool("si", false);
                    break;
                case 1:
                    _animator2.SetBool("si", false);
                    break;
                case 0:
                    SceneManager.LoadScene("Muerte");
                    break;
            }
        }
    }
}
