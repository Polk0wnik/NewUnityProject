
using System.Collections.Generic;
using UnityEngine;

public class FuncLessons : MonoBehaviour
{
    private int numberA = 15;
    private int numberB = 54;
    private string newText; 

    private List<string> nameEnemys = new List<string>();
    
    private void Start()//���������� ��������� � ������� �������, ������� ������ �� ���������
    {
        newText = ShowMyText();// �������������� ���������� 
        float Sum = Calculate(5425f, numberB); // ��������� ��������� 
    }


    private void TakeDamage(float damage, string text, bool isHas)// ��� ������� ����� 3 ��������� 
    {
        for (int i = 0; i < 15; i++)
        {
            //funtion
        }
    }

    private string ShowMyText()// ���������� ��� ������ - TextMeshProUGUI
    {
        string myText = "Hello World"; // local gameData
        return myText;
    }
    private float Calculate(float A , int B )
    {
         float C = A * B;  // C  - ��� ��������� ���������� � ��������� ��������;
        return C; //  return - ��������� �������� � ����� ����� ������
    }
}
