using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitDetector : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ground")) {
            Debug.Log(" Hit Any!");
            //TODO: dźwięk kraksy + czas na restart
            AdsManager Ad = new AdsManager();
            Ad.ShowInterstitialAd();
            SoundManager.PlaySound(SoundManager.Sound.Crash);
            StartCoroutine(waiter());
            
        }
        IEnumerator waiter( )
         {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
