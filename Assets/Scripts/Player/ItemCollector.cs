using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemCollector : MonoBehaviour
{   
    [SerializeField]private TextMeshProUGUI carrotsText;
    [SerializeField]private TextMeshProUGUI gemsText;
    private int carrots = 0;
    private int gems = 0;
    [SerializeField]private AudioSource carrotSound;
    [SerializeField]private AudioSource gemSound;
    void Start(){
        int collectedCarrot = PlayerPrefs.GetInt("CollectedCarrot");
        int collectedGem = PlayerPrefs.GetInt("CollectedGem");
        carrotsText.text = "Carrots : "+ PlayerPrefs.GetInt("CollectedCarrot");
        gemsText.text = "Gems : " + PlayerPrefs.GetInt("CollectedGem");
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Carrot")){
            carrots = PlayerPrefs.GetInt("CollectedCarrot");
            carrotSound.Play();
            Destroy(collision.gameObject);
            carrots++;
            carrotsText.text = "Carrots : "+ carrots;
            PlayerPrefs.SetInt("CollectedCarrot", carrots);
            
        }
        else if(collision.gameObject.CompareTag("Gem")){
            gems = PlayerPrefs.GetInt("CollectedGem");
            gemSound.Play();
            Destroy(collision.gameObject);
            gems++;
            gemsText.text = "Gems : "+ gems;
            PlayerPrefs.SetInt("CollectedCarrot", gems);
        }
    }
}