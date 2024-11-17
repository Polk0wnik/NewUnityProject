using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveDZ : MonoBehaviour
{

    private ZombieAnim zombieAnim2;
    private Rigidbody2D zombieRB2;
    private Transform transformZomby2;
    private float speedMove2 = 2f;
    private float timer2 = 4f;
    private float inputX2;
    private void Awake()
    {
        zombieAnim2 = GetComponent<ZombieAnim>();
        zombieRB2 = GetComponent<Rigidbody2D>();
        transformZomby2 = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            timer2 = Random.Range(3, 6);
            inputX2 = Random.Range(-1, 1);
            inputX2 = inputX2 < 0 ? 1 : -1;
        }
        float y = zombieRB2.velocity.y;
        zombieRB2.velocity = new Vector2(inputX2 * speedMove2, y);
        zombieAnim2.MoveAnim(Mathf.Abs(inputX2));
        InversDirectionMove(inputX2);
    }


    private void InversDirectionMove(float inputX)
    {
        if (inputX < 0)
        {
            transformZomby2.localScale = new Vector2(-0.5f, 0.5f);
        }
        else if (inputX > 0)
        {
            transformZomby2.localScale = new Vector2(0.5f, 0.5f);
        }
    }

}