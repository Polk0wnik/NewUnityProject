using System.Collections.Generic;
using UnityEngine;

public class ForArray : MonoBehaviour
{
    public string[] myArray = new string [3]; // ����� [3] - ��� ������ �������

    public List<string> myList = new List<string>(6); // ��� ������ ���������  � ����� ������ ������
    public List<int> myList1 = new List<int>(10);  
     

    private void Start()
    {
        //myArray[0] - ��� ���������� ����� ������ � �������
        myArray[0] = "sfsdf"; // �������� � ��������� ����
        myArray[1] = "asffa"; 
        myArray[2] = "tyulhbu";

        myList[0] = "�������"; //- ���� ��� �����
         
        myList.Add("Lenina");// ���� ������ �������� �� ����� ������
        myList.Remove("Pushkina"); // ��� � ������ ��� ����� ����� ����� ������
        bool isHas = myList.Contains("Lenina"); // ���� ������ ��� ����� � ������ �� ������ - true
         int count = myList.Count; //������ ������
    }
 
}
