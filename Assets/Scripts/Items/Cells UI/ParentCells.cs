 
using System.Collections.Generic;
using UnityEngine; 

public class ParentCells : MonoBehaviour
{
    private List<ChildCell> childCells = new List<ChildCell>();

    private void Awake()
    {
        childCells.AddRange(FindObjectsOfType<ChildCell>());

    }
    
    public void AddItem(ItemData newItem)
    {
        for (short index = 0; index < childCells.Count; index++)
        {   
            if(childCells[index].itemData == null)
            {
                childCells[index].SetDataItem(newItem);
                return;
            }  
        }   
    }
    public void RemoveItem(ItemData item)
    {
        for (short index = 0; index < childCells.Count; index++)
        {
            if (childCells[index].itemData == item)
            {
                childCells[index].ResetDataItem();
                return;
            }
        }
    }
}
