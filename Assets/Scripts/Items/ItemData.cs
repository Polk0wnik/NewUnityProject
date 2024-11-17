 
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObject/Items")]
public class ItemData : ScriptableObject
{
    public string nameItem;
    public short amount;
    public Sprite imageItem;
    public float heal;
    public short count;
    public bool isActive; 
}
