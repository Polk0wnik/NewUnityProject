
using System.Collections.Generic;
using UnityEngine;

public class FuncLessons : MonoBehaviour
{
    private int numberA = 15;
    private int numberB = 54;
    private string newText; 

    private List<string> nameEnemys = new List<string>();
    
    private void Start()//отсутсвуют параметры в круглых скобках, функция ничего не принемает
    {
        newText = ShowMyText();// инициализируем переменную 
        float Sum = Calculate(5425f, numberB); // принимает аргументы 
    }


    private void TakeDamage(float damage, string text, bool isHas)// это функция имеет 3 параметра 
    {
        for (int i = 0; i < 15; i++)
        {
            //funtion
        }
    }

    private string ShowMyText()// возвращает тип данных - TextMeshProUGUI
    {
        string myText = "Hello World"; // local gameData
        return myText;
    }
    private float Calculate(float A , int B )
    {
         float C = A * B;  // C  - это локальная переменная и результат сложения;
        return C; //  return - возращает значение с любым типом данных
    }
}
