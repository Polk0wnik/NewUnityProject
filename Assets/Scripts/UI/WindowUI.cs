using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WindowUI : MonoBehaviour
{
    private Shotting shotting;
    [SerializeField]private TextMeshProUGUI textCountBullets;
    
    private void Awake()
    {
        shotting = FindObjectOfType<Shotting>();
    }
    private void Update()
    {
        textCountBullets.text = shotting.GetCountBullet().ToString();
        OpenMenu();
    }
    public void OpenMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
               SceneManager.LoadScene(0);
        }
        
    }
}
