using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiMoveDZ3 : MonoBehaviour
{
    private ZombieAnim zombieAnim3;
    private Rigidbody2D zombieRB3;
    private Transform transformZomby3;
    [SerializeField] private Transform transformPersone;
    private float minDistanceAttacks = 10f;
    private float speedMove3 = 2f;
    private float timer_zombie = 4f;
    private float inputX3;
    private bool isAttack3 = false;
    private void Awake()
    {
        zombieRB3 = GetComponent<Rigidbody2D>();
        transformZomby3 = GetComponent<Transform>();
        zombieAnim3 = GetComponent<ZombieAnim>();
    }
    private void LateUpdate()
    {
        Moving3();
        CheckDistance();
    }
    private void Moving3()
    {
        timer_zombie -= Time.deltaTime;
        if (timer_zombie <= 0 && !isAttack3)
        {
            timer_zombie = Random.Range(3, 6);
            inputX3 = Random.Range(-1, 1);
            inputX3 = inputX3 < 0 ? -1 : 1;
        }

        float y = zombieRB3.velocity.y;
        zombieRB3.velocity = new Vector2(inputX3 * speedMove3, y);
        zombieAnim3.MoveAnim(Mathf.Abs(inputX3));
        InversDirectionMove(inputX3);
    }
    private void InversDirectionMove(float inputX)
    {
        float x = inputX < 0 ? -0.5f : 0.5f;
        transformZomby3.localScale = new Vector2(x, 0.5f);
    }
    private void AttackZombie()
    {
        Vector2 direction = transformPersone.position - transformZomby3.position;
        inputX3 = direction.x > 0 ? 1 : -1;

    }
    private void CheckDistance()
    {
        Vector2 distance = transformZomby3.position - transformPersone.position;
        if (distance.x < minDistanceAttacks)
        {
            AttackZombie();
            zombieAnim3.AttackAnim(true);
            isAttack3 = true;
        }
        else
        {
            zombieAnim3.AttackAnim(false);
            isAttack3 = false;
        }
    }
}
