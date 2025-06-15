using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Inventory playerInventory = collision.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.AddCollectible();
            Debug.Log("Player touched collectible");
        }
        else
        {
            Debug.LogWarning("Inventory component not found on player!");
        }

        Destroy(gameObject);
    }
}

