﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material; 
    Vector2 offset;

    public float xVelocity, yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material = GetComponent<Renderer>().material;
        // applique un offset variable au material, se qui fait scroll le background
        material.mainTextureOffset += offset * (Time.deltaTime / 3);
    }
}
