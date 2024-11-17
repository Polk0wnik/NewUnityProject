using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiMoveDZ4 : MonoBehaviour
{
    private ZombieAnim zombieAnim4;
    private Rigidbody2D zombieRB4;
    private Transform transformZomby4;
    [SerializeField] private Transform transformPersone4;
    private float minDistanceAttacks4 = 10f;
    private float speedMove4 = 2f;
    private float timer_zombie4 = 4f;
    private float inputX4;
    private bool isAttack4 = false;
    private void Awake()
    {
        zombieRB4 = GetComponent<Rigidbody2D>();
        transformZomby4 = GetComponent<Transform>();
        zombieAnim4 = GetComponent<ZombieAnim>();
    }
    private void LateUpdate()
    {
        Moving4();
        CheckDistance();
    }
    private void Moving4()
    {
        timer_zombie4 -= Time.deltaTime;
        if (timer_zombie4 <= 0 && !isAttack4)
        {
            timer_zombie4 = Random.Range(3, 6);
            inputX4 = Random.Range(-1, 1);
            inputX4 = inputX4 < 0 ? -1 : 1;
        }

        float y = zombieRB4.velocity.y;
        zombieRB4.velocity = new Vector2(inputX4 * speedMove4, y);
        zombieAnim4.MoveAnim(Mathf.Abs(inputX4));
        InversDirectionMove(inputX4);
    }
    private void InversDirectionMove(float inputX)
    {
        float x = inputX < 0 ? -0.5f : 0.5f;
        transformZomby4.localScale = new Vector2(x, 0.5f);
    }
    private void AttackZombie()
    {
        Vector2 direction = transformPersone4.position - transformZomby4.position;
        inputX4 = direction.x > 0 ? 1 : -1;

    }
    private void CheckDistance()
    {
        Vector2 distance = transformZomby4.position - transformPersone4.position;
        if (distance.x < minDistanceAttacks4)
        {
            AttackZombie();
            zombieAnim4.AttackAnim(true);
            isAttack4 = true;
        }
        else
        {
            zombieAnim4.AttackAnim(false);
            isAttack4 = false;
        }
    }
}
