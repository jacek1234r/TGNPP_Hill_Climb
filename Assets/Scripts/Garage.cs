using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Garage : MonoBehaviour
{
    private GameMaster gm;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Debug.Log("RETURNED TO GARAGE");
            
            SceneManager.LoadScene("Garage");
        }
    }
}
