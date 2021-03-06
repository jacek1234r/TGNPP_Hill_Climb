using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSound : MonoBehaviour
{
    bool reach = false;

    private void OnTriggerEnter2D( Collider2D collision ) {
        if (!reach) {
            reach = true;
            SoundManager.PlaySound(SoundManager.Sound.ReachCheckpoint);
            CarControler.obj.engine.pitch = 0.3f;
            CarControler.obj.setPause();
        }
    }
}
