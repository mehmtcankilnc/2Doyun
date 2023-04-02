using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    void Update()
    {
        if(aiPath.desiredVelocity.x >= .01f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else if (aiPath.desiredVelocity.x <= -.01f){
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
}