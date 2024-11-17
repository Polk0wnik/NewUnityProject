
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
        timer -= Time.deltaTime; // обратный отчет таймера
        if(timer <= 0 && !isAttack)// задается рандомное направление для зомби
        {
            timer = Random.Range(3,6);// рандомное число , обновляем счетчик таймера
            inputX =  Random.Range(-1, 1); // рандомное число 
            inputX = inputX < 0 ? -1 : 1; // округляем число до единицы
        }

        float y = zombieRB.velocity.y; //получаем "У", у зомби
        zombieRB.velocity = new Vector2(inputX * speedMove,y);// передвигаем зомби
        zombieAnim.MoveAnim(Mathf.Abs(inputX));// вызываем функцию анимации движения зомби
        InversDirectionMove(inputX); // инвертируем направление картинки зомби в -1 или 1
    }
    private void InversDirectionMove(float inputX)
    {
        float x = inputX < 0 ? -0.5f : 0.5f; // проверяем в каком направлении движется зомби
        transformZomby.localScale = new Vector2(x, 0.5f); // поворачиваем инверсией картинку зомби
    }
    private void AttackZombie() // задается конкретное направление для зомби
    {
        Vector2 direction = transformPersone.position-transformZomby.position;// расчитываем направление зомби 
        inputX = direction.x > 0 ? 1 : -1; // округляем дробные числа до единицы
        
    }
    private void CheckDistance()
    {
        Vector2 distance = transformZomby.position - transformPersone.position;// расчитываем растояние между зомб и игрок
        if(distance.x < minDistanceAttack) // переключения режима с атаки на свободное движение
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
        isWaitJump = false; // если зомби прыгнул нужно запретить повторно прыгать
    }
    private IEnumerator CheckMovingCoroutine() // Coroutine никогда не запускаем в Update
    { 
        while(true)
        {
            float second = 0.1f;
            currentPointZomby = transformZomby.position; // берем промежуточные координаты
            yield return new WaitForSeconds(second);// ждем секунду
            if(transformZomby.position == currentPointZomby) // проверяем текущие координаты с промежуточными
            {
                isWaitJump = true; // если координаты совпали то разрешаем прыгать
            }
        }  
    }
}
