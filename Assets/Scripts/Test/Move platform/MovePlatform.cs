using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform transformPlatform;
    public float minY = -3.6f;
    public float maxY = 3f;
    public float speed = 3f;
    public bool isUp = true;
    public bool isDown = false;

    private void Update()
    {
        if (isUp == true)
        {
            MoveUp();
        }
        else if (isDown == true)
        {
            MoveDown();
        }
    }

    private void MoveUp()
    {
        if (maxY > transformPlatform.position.y )
        {
            transformPlatform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            isUp = false;
            isDown = true;
        }
    }
    private void MoveDown()
    {
        if(minY < transformPlatform.position.y)
        {
            transformPlatform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            isDown = false;
            isUp = true;
        }
    }    
}
