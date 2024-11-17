
using System.Collections;
using UnityEngine; 

public class ZombyMove : MonoBehaviour
{ 
    private ZombieAnim zombieAnim;
    private Rigidbody2D zombieRB;
    private Transform transformZomby;
    private Vector3 currentPointZomby;
    [SerializeField] private Transform transformPersone;
    private float minDistanceAttack = 10f;
    private float speedMove = 2f;
    private float timer = 4f;
    private float inputX;
    private float jumpForce = 7f;
    private bool isJump = false;
    private bool isWaitJump = false;
    private bool isAttack = false;

    private void Awake()
    {
        zombieAnim = GetComponent<ZombieAnim>();
        zombieRB = GetComponent<Rigidbody2D>();
        transformZomby = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Moving();
        CheckDistance();
        if (isJump && isWaitJump)
        {
            Jumping();
        }
    }
    private void Start()
    {
        StartCoroutine(CheckMovingCoroutine());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isJump = true;
        }
    }

    private void Moving()
    {
        timer -= Time.deltaTime; // �������� ����� �������
        if(timer <= 0 && !isAttack)// �������� ��������� ����������� ��� �����
        {
            timer = Random.Range(3,6);// ��������� ����� , ��������� ������� �������
            inputX =  Random.Range(-1, 1); // ��������� ����� 
            inputX = inputX < 0 ? -1 : 1; // ��������� ����� �� �������
        }

        float y = zombieRB.velocity.y; //�������� "�", � �����
        zombieRB.velocity = new Vector2(inputX * speedMove,y);// ����������� �����
        zombieAnim.MoveAnim(Mathf.Abs(inputX));// �������� ������� �������� �������� �����
        InversDirectionMove(inputX); // ����������� ����������� �������� ����� � -1 ��� 1
    }
    private void InversDirectionMove(float inputX)
    {
        float x = inputX < 0 ? -0.5f : 0.5f; // ��������� � ����� ����������� �������� �����
        transformZomby.localScale = new Vector2(x, 0.5f); // ������������ ��������� �������� �����
    }
    private void AttackZombie() // �������� ���������� ����������� ��� �����
    {
        Vector2 direction = transformPersone.position-transformZomby.position;// ����������� ����������� ����� 
        inputX = direction.x > 0 ? 1 : -1; // ��������� ������� ����� �� �������
        
    }
    private void CheckDistance()
    {
        Vector2 distance = transformZomby.position - transformPersone.position;// ����������� ��������� ����� ���� � �����
        if(distance.x < minDistanceAttack) // ������������ ������ � ����� �� ��������� ��������
        {
            AttackZombie();
            zombieAnim.AttackAnim(true);
            isAttack = true;
        }
        else
        {
            zombieAnim.AttackAnim(false);
            isAttack = false;
        }
    }

    private void Jumping()
    { 
        zombieRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJump = false;
        isWaitJump = false; // ���� ����� ������� ����� ��������� �������� �������
    }
    private IEnumerator CheckMovingCoroutine() // Coroutine ������� �� ��������� � Update
    { 
        while(true)
        {
            float second = 0.1f;
            currentPointZomby = transformZomby.position; // ����� ������������� ����������
            yield return new WaitForSeconds(second);// ���� �������
            if(transformZomby.position == currentPointZomby) // ��������� ������� ���������� � ��������������
            {
                isWaitJump = true; // ���� ���������� ������� �� ��������� �������
            }
        }  
    }
}
