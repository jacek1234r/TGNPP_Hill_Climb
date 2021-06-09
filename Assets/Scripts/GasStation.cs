using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasStation : MonoBehaviour
{
    private GameMaster gm;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Debug.Log("FINISH!");
            //TODO: dźwięk tankowania + czas + podsumowanie
            
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gm.lastCheckPointPos = gm.startPostion;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
