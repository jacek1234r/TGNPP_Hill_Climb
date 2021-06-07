using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillTank : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CarControler.obj.tank = Math.Min(CarControler.obj.maxTank, CarControler.obj.tank + 1.3f);
        Destroy(gameObject);
    }
}
