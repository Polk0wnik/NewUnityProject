using System;
using UnityEngine;

[Serializable]
public class GameData
{
    private float xPers, yPers, zPers;
    private float xZom, yZom, zZom;
    private float personeHP;
    private float zombyHP;
    public void SavePersoneData(Vector3 pos, float hp)
    {
        xPers = pos.x;
        yPers = pos.y;
        zPers = pos.z;
        personeHP = hp;
    }
    
    public void LoadPersoneData(out Vector3 pos, out float HP)
    {
        pos.x = xPers;
        pos.y = yPers;
        pos.z = zPers;
        HP = personeHP;
    }

    public void SaveZombyData(Vector3 pos, float hp)
    {
        xZom = pos.x;
        yZom = pos.y;
        zZom = pos.z;
        zombyHP = hp;
    }

    public void LoadZombyData(out Vector3 pos, out float HP)
    {
        pos.x = xZom;
        pos.y = yZom;
        pos.z = zZom;
        HP = zombyHP;
    }
}
