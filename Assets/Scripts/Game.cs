using UnityEngine;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public GameObject StartMenu;    //UI
    public GameObject WinMenu;      //UI
    public GameObject LoseMenu;     //UI

    public void OnPlayerStart()
    {
        StartMenu.SetActive(false); //UI
        Controls.enabled = true;    //UI
    }
    public void OnPlayerDie()
    {
        Controls.enabled = false;   //UI
        LoseMenu.SetActive(true);   //UI
    }
    public void OnPlayerWin()
    {
        Controls.enabled = false;   //UI
        LevelIndex++;               //UI
        WinMenu.SetActive(true);    //UI
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