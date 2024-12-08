
using UnityEngine;
using UnityEngine.UI;

public class PersonHPUI : MonoBehaviour
{
    private Image imageHP;
    public static float CurentHP = 100f;
    public PersoneData data;

    private void OnEnable()
    {
        CurentHP = data.currentHP;
    }
    private void OnDisable()
    {
        data.currentHP = CurentHP;
    }

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
