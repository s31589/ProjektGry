using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public float fallThreshold = -10f; 

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            isDead();
        }
    }

    void isDead()
    {
        Debug.Log("Gracz umarl po upadku z mapy.");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}

