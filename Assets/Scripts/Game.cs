using UnityEngine;

public class Game : MonoBehaviour
{
    //public Controls Controls;


    public void OnPlayerDie()
    {
       
        //Controls.enabled = false;
        //LoseMenu.SetActive(true);
    }

    public void OnPlayerReachedFinish()
    {

        //Controls.enabled = false;
        LevelIndex++;
        //WinMenu.SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
}