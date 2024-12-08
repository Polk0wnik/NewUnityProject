using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public PersoneData personData;
    public async void SaveDatas()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt"); //�������� ���� ������������� �� ����� ����������
        await SaveDataAsync(personData.gameData, filePath);
    }
    public async void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        personData.gameData = await LoadDataAsync(filePath);
    }
    private async Task SaveDataAsync(GameData data, string filePath) // Async ����������� ���������������� �� ���������� ������
    {
        BinaryFormatter formatter = new BinaryFormatter(); // �������� ������������ ���������� ������

        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // ������� ����� 
        {
            await Task.Run(() => formatter.Serialize(stream, data)); // ����� ��������� ���������� ������ ����������
        }
    }
    private async Task<GameData> LoadDataAsync(string filePath) //����������  Task<GameDatas>
    {
        if (File.Exists(filePath))// �������� ������� ����� ����� �� ����
        {
            BinaryFormatter formatter = new BinaryFormatter();// �������� ������������ 

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))// ������� ����� 
            {
                return await Task.Run(() => formatter.Deserialize(stream)) as GameData;// ����� ��������� �������� ������ ����������
            }
        }
        return null;// ���� �������� �� ������� �� ������ null;
    }
}
