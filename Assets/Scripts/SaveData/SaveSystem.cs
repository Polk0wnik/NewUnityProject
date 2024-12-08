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
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt"); //создание пути автоматически на любом устроцстве
        await SaveDataAsync(personData.gameData, filePath);
    }
    public async void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        personData.gameData = await LoadDataAsync(filePath);
    }
    private async Task SaveDataAsync(GameData data, string filePath) // Async асинхронное программирование не возвращ€ет ничего
    {
        BinaryFormatter formatter = new BinaryFormatter(); // бинарна€ сериализаци€ сохранини€ данных

        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // создаем потом 
        {
            await Task.Run(() => formatter.Serialize(stream, data)); // Ћ€мда выражени€ сохранени€ данных асинхронно
        }
    }
    private async Task<GameData> LoadDataAsync(string filePath) //возвращ€ет  Task<GameDatas>
    {
        if (File.Exists(filePath))// проверка наличие такго файла по пути
        {
            BinaryFormatter formatter = new BinaryFormatter();// бинарна€ сериализаци€ 

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))// создаем потом 
            {
                return await Task.Run(() => formatter.Deserialize(stream)) as GameData;// Ћ€мда выражени€ выгрузка данных асинхронно
            }
        }
        return null;// если проверка не удалась то вернет null;
    }
}
