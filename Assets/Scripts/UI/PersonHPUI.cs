
using UnityEngine;
using UnityEngine.UI;

public class PersonHPUI : MonoBehaviour
{
    private Image imageHP;
    public static float CurentHP = 100f;

    private void Awake()
    {
        imageHP = GetComponent<Image>();
        
    }
    private void Update()
    {
        imageHP.fillAmount = CurentHP/100f;
        
    }
    public void HealHP(float heal)
    {
        if (CurentHP > 0 && CurentHP < 100)
        {
            CurentHP += heal;
        }
    }
}
