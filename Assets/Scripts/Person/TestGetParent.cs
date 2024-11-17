using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetParent : MonoBehaviour
{
    private Collider2D personeCollider;
    private Collider2D personeCollider1;
    private void Awake()
    {
        personeCollider = transform.GetComponentInParent<Collider2D>();
        personeCollider1 = GetComponent<Collider2D>();
    }
    private void Start()
    {
        //Debug.Log(personeCollider.gameObject.tag);
        //Debug.Log(personeCollider1.gameObject.tag);
    }
}
