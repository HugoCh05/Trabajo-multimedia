using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5){
            SceneManager.LoadScene("muerte");
        }
    }
}
