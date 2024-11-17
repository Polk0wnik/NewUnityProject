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
        // смещаем позицию камеры от точки ј к точке ¬ тоесть от текущей позиции к позиции игрока
        cameraTr.position = Vector2.Lerp(cameraTr.position, persone.transform.position, Time.deltaTime);
        // просто фикс бага
        cameraTr.position = new Vector3(cameraTr.position.x, cameraTr.position.y, -10);
    }
}
