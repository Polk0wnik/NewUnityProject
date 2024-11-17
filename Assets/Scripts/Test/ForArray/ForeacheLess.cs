
using System.Collections.Generic;
using UnityEngine;

public class ForeacheLess : MonoBehaviour
{
    public List<GameObject> myGameObjects = new List<GameObject>();
    public List<SpriteRenderer> myRenderers = new List<SpriteRenderer>();
    private bool isHAs = true;

    public void Start()
    {
        
        for (int i = 0; i < myGameObjects.Count; i++) // != знак не равенства， == знак равенства，
                                                      // >= больше или равно，<= меньше или равно, ++ увеличить на +1
        {
            Debug.Log("for = " + i);
            myGameObjects[i].SetActive(true);
            Check(i);
        }

    }
    private void Check(int index)
    {
        if (index % 2 ==0) // пишем условие 
        { 
            myRenderers[index].color = Color.red;
            isHAs = true;
        }
        else // либо
        {
            myRenderers[index].color = Color.black;
            isHAs = false;
        }
    }
    private void CheckBool()
    {
        if (isHAs) // означает что isHas должен быть true
        {
            //Jumping
        }
        else // означает что isHas должен быть false
        {
          //deadEnemy
        }
    }
}
;