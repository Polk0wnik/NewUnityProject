 
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    private Rigidbody2D perRigidbody;
    private  Transform transformPersone;
    private PersonAnimator personeAnimator;
    private GunRotation gun;
    [SerializeField] private Transform startPoint;
    public PersoneData data;

    [SerializeField] private float speed = 30f;
    [SerializeField] private float forceJump = 20f;
    
    private bool isGround = false;

    private void OnEnable()
    {
        Time.timeScale = 1f;
        transformPersone.position = data.position;
    }
    private void OnDisable()
    {
        data.position = transformPersone.position;
    }
    private void Awake()
    {
        personeAnimator = GetComponent<PersonAnimator>();
        transformPersone = GetComponent<Transform>();
        perRigidbody = GetComponent<Rigidbody2D>();
        gun = transformPersone.GetChild(1).GetComponent<GunRotation>();  
    }
    private void LateUpdate()
    { 
        if (isGround)
        {
            Jumping(); 
        }
        Moving();
    }
    private void InversDirection(float x)
    {    
        if(x<0)
        {
            transformPersone.localScale = new Vector2(-1f, 1f);
            startPoint.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (x>0)
        {
            startPoint.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
            transformPersone.localScale = new Vector2(1f, 1f);
        }
    }
    public void Moving()
    {   
        // получаем направление
        float x = Input.GetAxis("Horizontal"); // key - A, Key - D, xPers = -1f или xPers = 1f, xPers = 0f
       //float yPers = Input.GetAxis("Vertical");

        gun.UpdateDirectionGun(x);
        InversDirection(x);
        personeAnimator.MoveAnim(x);
        perRigidbody.velocity = new Vector2( x * speed, perRigidbody.velocity.y); // двигаем игрока по направлению
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            personeAnimator.JumpAnim(true);
            perRigidbody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse); // совершаем прыжок через физику rigidbody
            isGround = false;
        } 
        else
         {
            personeAnimator.JumpAnim(false);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {   
         // проверяем что игрок находится на земле для прыжков
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
}
