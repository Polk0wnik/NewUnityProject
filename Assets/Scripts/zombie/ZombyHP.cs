
using UnityEngine;

public class ZombyHP : MonoBehaviour
{ 
    public float currentHP = 100;
    private float damage = 5f;
    public ZombyData zombyData;
    private void OnEnable()
    {
        currentHP = zombyData.zombyHP;
    }
    private void OnDestroy()
    {
        zombyData.zombyHP = currentHP;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (currentHP < 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                currentHP -= damage;
                Destroy(collision.gameObject);
            }
        }
    }
}
