using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HitDetector : MonoBehaviour {
    public GameObject MenuMenu;
    public GameObject MenuMenu1;
    public GameObject EndMenu;
    public static HitDetector obj;
    public GameObject countDownTimerText;

    int countDownStartValue = 4;

    public void Awake() {
        if (obj == null) {
            obj = this;
            
        }
    }

    void countDownTimer() {
        if (countDownStartValue > 0) {
            if(countDownStartValue == 4) {
                Debug.Log("GAME OVER");
                countDownTimerText.GetComponent<TMPro.TextMeshProUGUI>().text = "GAME OVER";
                countDownStartValue--;
            } else {
                Debug.Log("Timer: "+countDownStartValue);
                countDownTimerText.GetComponent<TMPro.TextMeshProUGUI>().text = ""+countDownStartValue;;
                countDownStartValue--;
            }
            
            Invoke("countDownTimer", 1.0f);
        } else {
            Debug.Log("Restarting...");
            resetLevel();
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
            //StartCoroutine( waiter() );
            countDownTimer();

        }
    }

    private void resetLevel() {
        HitDetector.obj.MenuMenu.SetActive(false);
        HitDetector.obj.MenuMenu1.SetActive(true);
        HitDetector.obj.EndMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
