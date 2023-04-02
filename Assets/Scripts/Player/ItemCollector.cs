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
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Carrot")){
            Destroy(collision.gameObject);
            carrots++;
            carrotsText.text = "Carrots : "+ carrots;
        }
        else if(collision.gameObject.CompareTag("Gem")){
            Destroy(collision.gameObject);
            gems++;
            gemsText.text = "Gems : "+ gems;
        }
    }
}