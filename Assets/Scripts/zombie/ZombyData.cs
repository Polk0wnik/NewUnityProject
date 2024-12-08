using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewZomby" , menuName = "Zomby")]
public class ZombyData : ScriptableObject
{
    public float zombyHP;
    public Vector3 zombyPos;
    public GameData gameData;

    public void SaveZomby()
    {
        gameData.SaveZombyData(zombyPos, zombyHP);
    }

    public void LoadZomby()
    {
        gameData.LoadZombyData(out zombyPos, out zombyHP);
    }
    
    public void RestartZomby()
    {
        zombyHP = 100f;
        zombyPos = new Vector3(0,0,0);
    }
}
