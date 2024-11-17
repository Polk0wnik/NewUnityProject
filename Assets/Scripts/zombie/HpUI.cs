
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    private Image imageHp;
    private TextMeshProUGUI textHP;
    private ZombyHP hp;
    private void Awake()
    {
        imageHp = transform.GetChild(0).GetComponent<Image>();
        hp = GetComponent<ZombyHP>();
    }
    private void Update()
    {
        imageHp.fillAmount = hp.currentHP / 100f;
    }
}

