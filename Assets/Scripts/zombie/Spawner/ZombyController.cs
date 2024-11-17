using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombyController : MonoBehaviour
{
    private ZombyHP zomby;
    private List<ZombyPoints> pointsZ = new List<ZombyPoints>();
    private Vector3 poinZ;

    private void Awake()
    {
        zomby = FindObjectOfType<ZombyHP>(true);
        pointsZ.AddRange(FindObjectsOfType<ZombyPoints>(true));
        poinZ = zomby.transform.position;
    }

    private void Update()
    {
        if(zomby.currentHP < 0)
        {
            zomby.gameObject.SetActive(true);
            int index = Random.Range(0, 3);
            float x = pointsZ[index].transform.position.x;
            float y = pointsZ[index].transform.position.y;
            poinZ = new Vector3(x, y, 0);
            zomby.transform.position = poinZ;
            zomby.currentHP = 100;
        }
    }
}
