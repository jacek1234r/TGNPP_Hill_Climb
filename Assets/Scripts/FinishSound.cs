using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSound : MonoBehaviour
{
    bool reach = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (!reach)
        {
            reach = true;
            SoundManager.PlaySound(SoundManager.Sound.ReachCheckpoint);
            Sterowanie.obj.engine.pitch = 0.3f;
            Sterowanie.obj.setPause();
        }
    }
}
