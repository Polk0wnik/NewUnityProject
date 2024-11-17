using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveDZ4 : MonoBehaviour
{
    private ZombieAnim zombieAnim4;
    private Rigidbody2D zombieRB4;
    private Transform transformZomby4;
    private Vector3 currentPointZomby4;
    [SerializeField] private Transform transformPersone4;
    private float minDistanceAttack4 = 10f;
    private float timer4 = 4f;    
    private float speedMove4 = 2f;
    private float inputX4;
    private float jumpForce4 = 7f;
    private bool isJump4 = false;
    private bool isWaitJump4 = false;
    private bool isAttack4 = false;

    private void Awake()
    {
        zombieRB4 = GetComponent<Rigidbody2D>();
        zombieAnim4 = GetComponent<ZombieAnim>();
        transformZomby4 = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Moving4();
        CheckDistance4();
        if (isJump4 && isWaitJump4)
        {
            Jumping();
        }
    }
    private void Start()
    {
        StartCoroutine(CheckMoving4());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJump4 = true;
        }
    }

    private void Moving4()
    {
        timer4 -= Time.deltaTime;
        if (timer4 <= 0 && !isAttack4)
        {
            timer4 = Random.Range(3, 6);
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
    private void CheckDistance4()
    {
        Vector2 distance = transformZomby4.position - transformPersone4.position;
        if (distance.x < minDistanceAttack4)
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
    private void Jumping()
    {
        zombieRB4.AddForce(Vector2.up * jumpForce4, ForceMode2D.Impulse);
        isJump4 = false;
        isWaitJump4 = false;
    }
    private IEnumerator CheckMoving4()
    {
        while (true)
        {
            float second = 0.1f;
            currentPointZomby4 = transformZomby4.position; 
            yield return new WaitForSeconds(second);
            if (transformZomby4.position == currentPointZomby4) 
            {
                isWaitJump4 = true;
            }
        }
    }
}
