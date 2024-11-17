
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChildCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData itemData;
    private Image imageCell;
    private TextMeshProUGUI itemText;
    private RectTransform itemTrans;
    public short index;
    private string nameItem = " ";
    private PersonHPUI personHP;
    private Shotting shot;

    private void Awake()
    {
        itemTrans = GetComponent<RectTransform>();
        imageCell = GetComponent<Image>();
        itemText = itemTrans.GetChild(0).GetComponent<TextMeshProUGUI>();
        personHP = FindObjectOfType<PersonHPUI>();
        shot = FindObjectOfType<Shotting>();
    }
    public void SetDataItem(ItemData itemData)
    {
        this.itemData = itemData;
        imageCell.sprite = itemData.imageItem; //error null
        itemText.text = itemData.nameItem;
    }
    public void ResetDataItem()
    {
        itemData = null;
        imageCell.sprite = null;
        itemText.text = nameItem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (itemData != null)
            {
                personHP.HealHP(itemData.heal);
                shot.UpdateCountBullet(itemData.count);
                ResetDataItem();
            }
        }      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemTrans.localScale = new Vector3(1.2f , 1.2f , 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemTrans.localScale = new Vector3(1, 1, 0);
    }
}
