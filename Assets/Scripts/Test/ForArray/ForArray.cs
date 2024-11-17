using System.Collections.Generic;
using UnityEngine;

public class ForArray : MonoBehaviour
{
    public string[] myArray = new string [3]; // масив [3] - это размер массива

    public List<string> myList = new List<string>(6); // это список элементов  с типом данных стринг
    public List<int> myList1 = new List<int>(10);  
     

    private void Start()
    {
        //myArray[0] - это пор€дковый номер €чейки в массиве
        myArray[0] = "sfsdf"; // элементы с названием улиц
        myArray[1] = "asffa"; 
        myArray[2] = "tyulhbu";

        myList[0] = "ываываы"; //- тоже как масив
         
        myList.Add("Lenina");// если список заполнен то будет ошибка
        myList.Remove("Pushkina"); // тут в списке нет такой улицы будет ошибка
        bool isHas = myList.Contains("Lenina"); // если найдет эту улицу в списке то вернет - true
         int count = myList.Count; //размер списка
    }
 
}
