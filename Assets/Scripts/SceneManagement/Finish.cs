using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]private AudioSource finishSound;
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "Player"){
            finishSound.Play();
            Invoke("completeLevel", 2f);
        }
    }
    private void completeLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

