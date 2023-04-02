using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemCollector : MonoBehaviour
{   
    [SerializeField]private TextMeshProUGUI carrotsText;
    private int carrots=0;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Carrot")){
            Destroy(collision.gameObject);
            carrots++;
            carrotsText.text = "Carrots: "+ carrots;
        }
    }
}