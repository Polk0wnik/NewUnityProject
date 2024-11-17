 
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemData item;
    private ParentCells parentCells;
    private MovePerson persone;
    private Transform persTrans;
    private Transform itemTrans;
    private float minDist = 1.5f;
    private void OnEnable()
    {
        item.isActive = true;
    }
    private void OnDisable()
    {
        item.isActive = false;
    }
    private void Awake()
    {
        itemTrans = GetComponent<Transform>();
        persone = FindObjectOfType<MovePerson>();
        persTrans = persone.GetComponent<Transform>();
        parentCells = FindObjectOfType<ParentCells>();

    } 
    private void PickUp()
    {
        gameObject.SetActive(false);
        parentCells.AddItem(item);
    }


    // 1 проверить что подключин using UnityEngine.EventSystems;
    // 2 проверить что подключен интерфейс IPointerClickHandler
    // 3 проверить что в иерархии есть UI объект EventSystems
    // 4 проверить что на камере есть компонент PhysicsRaycast2D
    // 5 проверить что на предметах которые будем подбирать есть компонент Collider
    // 6 проверить что на предметах висит этот скрипт которые будем подбрать
    public void OnPointerClick(PointerEventData eventData)
    {   
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            float distance = Vector3.Distance(itemTrans.position, persTrans.position); // Получаем текущее растояние
            if (minDist <= distance)// проверяем минимальное растояние между предметом и игроком 
            {
                PickUp();
            }
        }
        
    }
}
