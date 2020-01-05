using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroll : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public float xVelocity, yVelocity;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //on change la vitesse en fonction de la difficulté de ParamManager
        if (ParamManager.Instance.difficulty.Equals(ParamManager.Normal) || ParamManager.Instance.difficulty.Equals(ParamManager.Easy))
        {
            xVelocity = (float)1;
        }
        else
        {
            xVelocity = (float)1.5;
        }
        // applique un offset variable au material, se qui fait scroll le background
        offset = new Vector2(xVelocity, yVelocity);
        material.mainTextureOffset += offset * (Time.deltaTime / 3);
    }
}
