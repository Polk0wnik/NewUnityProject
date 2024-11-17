using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    private List<PointItem> pointsItem = new List<PointItem>();
    public List<GameObject> itemsGM = new List<GameObject>();
    [SerializeField] private ItemData heal;
    [SerializeField]private ItemData food;
    [SerializeField]private ItemData bullet;
    private float timer = 15f;
    private void Awake()
    {
        pointsItem.AddRange(FindObjectsOfType<PointItem>(true));
    }
    private void Start()
    {
        SpawnItem();
       
    }
    public void SpawnItem()
    {
        for (short i = 0; i < pointsItem.Count; i++)
        {
            Instantiate(itemsGM[i].gameObject, pointsItem[i].transform.position,Quaternion.identity);
        } 
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (!heal.isActive && timer <= 0)
        {
            timer = 15;
            SpawnItem();
        }
    }

    
}
