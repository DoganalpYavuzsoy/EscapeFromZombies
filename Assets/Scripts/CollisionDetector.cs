using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public PlayerMovement player;
    
    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Çarpýþma Gerçekleþti.");
        Destroy (this.gameObject,1);
        player.takeDamage(-30);
    }
}
