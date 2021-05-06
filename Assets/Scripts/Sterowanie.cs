using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Sterowanie : MonoBehaviour
{
    public Rigidbody2D FrontTire;
    public Rigidbody2D BackTire;
    public Rigidbody2D Vehicle;
    public float speed;
    public float movement;
    public float maxTank = 3f;
    public float tank = 3f;
    public float zuzyciePaliwa = 0.001f;
    public Image gasImage;
    public static Sterowanie obj;
    public bool onPause = true;
    public GameObject menu;


    public void Awake()
    {
        if(obj==null)
        {
            obj = this;
        }
    }
    // Start is called before the first frame update
    public void StartEtap()
    {
        tank = 3f;
        onPause = false;
    }
    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        gasImage.fillAmount = tank/3;
        if (Input.GetKeyDown("escape"))
        {
            if (onPause == false)
            {
                onPause = true;
                Sterowanie.obj.menu.SetActive(true);

            }
            else
            {
                onPause = false;
                Sterowanie.obj.menu.SetActive(false);

            }
            //print("esc");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (tank > 0 )
        if(onPause==false)
        {

        FrontTire.AddTorque( -movement * speed * Time.fixedDeltaTime );
        BackTire.AddTorque( -movement * speed * Time.fixedDeltaTime );
        Vehicle.AddTorque( movement * speed * Time.fixedDeltaTime );
        tank -= Math.Abs( zuzyciePaliwa * movement * Time.fixedDeltaTime );
        }
    }
}
