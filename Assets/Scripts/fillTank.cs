using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillTank : MonoBehaviour
{

    Boolean reached = false;
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!reached) {
            reached = true;
            CarControler.obj.tank = Math.Min(CarControler.obj.maxTank, CarControler.obj.tank + 1.3f );
            SoundManager.PlaySound(SoundManager.Sound.fillTank);
            Destroy(self);
        }
    }
}
