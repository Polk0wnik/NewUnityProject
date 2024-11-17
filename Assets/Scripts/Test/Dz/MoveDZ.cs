using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDZ : MonoBehaviour
{
    public Transform Platform;
    public float minim = -3.6f;
    public float maxim = 3f;
    public float speed = 3f;
    public bool isLeft = true;
    
    private void Update()
    {
        if (isLeft == false)
        {
            MoveRight();
        }
        else if (isLeft == true)
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        if (maxim > Platform.position.x)
        {
            Platform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            isLeft = true;
        }
    }
    private void MoveLeft()
    {
        if (minim < Platform.position.x)
        {
            Platform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            isLeft = false;
        }
    }

}