using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fillTank : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sterowanie.obj.tank = Math.Min( Sterowanie.obj.maxTank, Sterowanie.obj.tank + 1.3f );
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
