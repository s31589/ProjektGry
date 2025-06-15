using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int collectibleCount = 0;
    public TextMeshProUGUI collectibleText;

    void Start()
    {
        UpdateCollectibleUI();
    }

    public void AddCollectible()
    {
        collectibleCount++;
        Debug.Log("AddCollectible() called");
        Debug.Log("Collected: " + collectibleCount);
        UpdateCollectibleUI();
    }

    private void UpdateCollectibleUI()
    {
        if (collectibleText != null)
        {

        collectibleText.text = "Collectibles: " + collectibleCount;

        }
    }

}