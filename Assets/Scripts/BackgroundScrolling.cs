using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    Material material;
    Vector2 offset;
    public static float xVel = 0.25f, yVel = 0;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    void Start()
    {

    }
    void Update()
    {
        offset = new Vector2(xVel, yVel);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
