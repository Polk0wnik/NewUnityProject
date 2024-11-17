using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPoint;
    private short countBullet = 30;
   
    private void Update()
    {
        SpawnBullet();
    }
    private void SpawnBullet()
    {
        if(Input.GetMouseButtonDown(0) && countBullet > 0)
        {   
            // спавним новые объекты пулек из префаба на сцене при нажатии на кнопку
            GameObject newBullet = Instantiate(bullet,startPoint.position,transform.rotation);
            newBullet.transform.right = startPoint.right;
            countBullet -= 1; 
        }
    }
    public void UpdateCountBullet(short newBulletCount ) 
    {
        countBullet += newBulletCount;
    }
    public short GetCountBullet()
    {
        return countBullet;
    }
}
