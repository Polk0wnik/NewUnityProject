 
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


    // 1 ��������� ��� ��������� using UnityEngine.EventSystems;
    // 2 ��������� ��� ��������� ��������� IPointerClickHandler
    // 3 ��������� ��� � �������� ���� UI ������ EventSystems
    // 4 ��������� ��� �� ������ ���� ��������� PhysicsRaycast2D
    // 5 ��������� ��� �� ��������� ������� ����� ��������� ���� ��������� Collider
    // 6 ��������� ��� �� ��������� ����� ���� ������ ������� ����� ��������
    public void OnPointerClick(PointerEventData eventData)
    {   
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            float distance = Vector3.Distance(itemTrans.position, persTrans.position); // �������� ������� ���������
            if (minDist <= distance)// ��������� ����������� ��������� ����� ��������� � ������� 
            {
                PickUp();
            }
        }
        
    }
}
