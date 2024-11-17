using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoneCamera : MonoBehaviour
{
    private Transform cameraTr;
    private MovePerson persone; 

    private void Start()
    {
        cameraTr = GetComponent<Transform>();
        persone = FindObjectOfType<MovePerson>(); 
    }

    private void Update()
    { 
        // ������� ������� ������ �� ����� � � ����� � ������ �� ������� ������� � ������� ������
        cameraTr.position = Vector2.Lerp(cameraTr.position, persone.transform.position, Time.deltaTime);
        // ������ ���� ����
        cameraTr.position = new Vector3(cameraTr.position.x, cameraTr.position.y, -10);
    }
}
