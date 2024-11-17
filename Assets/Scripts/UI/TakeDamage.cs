
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {   
            if(PersonHPUI.CurentHP >=0)
            {
                PersonHPUI.CurentHP -= 25f;
            }
            else
            {
                Debug.Log("Player Dead");
                Time.timeScale = 0f;
            }
             
        }
    }
}
