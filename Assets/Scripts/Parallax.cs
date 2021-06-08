using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, lastPos;
    public GameObject cam;
    public float parallaxEffect;

    void Start() {
        lastPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(lastPos + dist, transform.position.y, transform.position.z);        
        if (temp > lastPos + length) lastPos += length;
        else if (temp < lastPos - length) lastPos -= length;
    }
}
