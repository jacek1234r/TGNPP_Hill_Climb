using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOn : MonoBehaviour
{
    public static dontDestroyOn instance;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        Radio.obj.PlayNexStation();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
