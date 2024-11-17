 
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject gun;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gun.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        gun.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gun.SetActive(true);
    } 
}
