using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour {
    private GameMaster gm;
    Boolean reached = false;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!reached)
        {
            reached = true;
            SoundManager.PlaySound(SoundManager.Sound.ReachCheckpoint);
            if (collision.CompareTag("Player"))
            {
                gm.lastCheckPointPos = transform.position;
                Debug.Log("Checkpoint Saved");
            }
        }
    }
}
