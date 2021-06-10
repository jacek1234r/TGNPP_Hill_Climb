using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillTank : MonoBehaviour
{
    Boolean reached = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!reached) {
            reached = true;
            this.GetComponent<Renderer>().enabled = false;
            CarControler.obj.tank = Math.Min(CarControler.obj.maxTank, CarControler.obj.tank + 1.3f );
            SoundManager.PlaySound(SoundManager.Sound.fillTank);
        }
    }
}
