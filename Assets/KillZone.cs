using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement playerMovement = other.GetComponent<Movement>();

            if (playerMovement != null)
            {
                playerMovement.Respawn();
            }
        }
//        else
//        {
//            // For other objects (e.g., enemies), destroy them
//            Destroy(other.gameObject);
//        }
    }
}