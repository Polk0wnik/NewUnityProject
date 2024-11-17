using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTest : MonoBehaviour
{
    public Rigidbody2D rigidbodyCube;
    public float force = 15f;
    public float forceRotation = 45f;

    private void Start()
    {
        rigidbodyCube.AddForce(Vector2.up * force,ForceMode2D.Impulse);
        rigidbodyCube.AddTorque(forceRotation);
        rigidbodyCube.MoveRotation(forceRotation);
        rigidbodyCube.MovePosition(rigidbodyCube.position + Vector2.up  * force);
    }
    public void AddForceCastom(Vector3 direction)
    {
        Debug.Log(direction);
    }
}