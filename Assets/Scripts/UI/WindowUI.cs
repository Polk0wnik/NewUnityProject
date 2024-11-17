using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    }
}
