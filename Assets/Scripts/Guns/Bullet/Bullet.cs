
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bulletTransform;
    public float speed = 10f;
    public float timer = 5f;


    private void Awake()
    {
        bulletTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }   
        bulletTransform.position += bulletTransform.right * Time.deltaTime * speed;

    }
}
