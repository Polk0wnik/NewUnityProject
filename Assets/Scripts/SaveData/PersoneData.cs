using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PersoneData", menuName = "Persone")]
public class PersoneData : ScriptableObject
{
    public Vector3 position;
    public float currentHP;
    public GameData gameData;
    public void SavePersoneData()
    {
        gameData.SavePersoneData(position, currentHP);
    }
    public void LoadPersoneData()
    {
        gameData.LoadPersoneData(out position, out currentHP);

    }
    public void RestartPersoneData()
    {
        position = new Vector3(0, 0, 0);
        currentHP = 100f;
    }
}
