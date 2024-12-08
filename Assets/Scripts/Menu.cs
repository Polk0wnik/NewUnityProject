
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public SaveSystem saveSystem;
    public PersoneData personeData;
    public ZombyData zombyData;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SaveButton()
    {
        zombyData.SaveZomby();
        personeData.SavePersoneData();
        saveSystem.SaveDatas();
    }

    public void LoadButton()
    {
        saveSystem.LoadData();
        personeData.LoadPersoneData();
        zombyData.LoadZomby();
        SceneManager.LoadScene(1);
    }

    public void ReStartButton()
    {
        zombyData.RestartZomby();
        personeData.RestartPersoneData();
        SceneManager.LoadScene(1);
    }
}
