using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitDetector : MonoBehaviour {
    public GameObject MenuMenu;
    public GameObject MenuMenu1;
    public GameObject EndMenu;
    public static HitDetector obj;
    public void Awake()
    {
        if (obj == null)
        {
            obj = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ground")) {
            Debug.Log(" Hit Any!");
            HitDetector.obj.MenuMenu.SetActive(true);
            HitDetector.obj.MenuMenu1.SetActive(false);
            HitDetector.obj.EndMenu.SetActive(true);
            CarControler.obj.onPause = true;
            //TODO: czas na restart
            //AdsManager Ad = new AdsManager();
            //Ad.ShowInterstitialAd();
            SoundManager.PlaySound(SoundManager.Sound.Crash);
            StartCoroutine( waiter() );


        }
        IEnumerator waiter( )
         {
            yield return new WaitForSeconds(4);
            HitDetector.obj.MenuMenu.SetActive(false);
            HitDetector.obj.MenuMenu1.SetActive(true);
            HitDetector.obj.EndMenu.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
}
