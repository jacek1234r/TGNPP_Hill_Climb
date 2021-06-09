using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitDetector : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ground")) {
            Debug.Log(" Hit Any!");
            //TODO: dźwięk kraksy + czas na restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
