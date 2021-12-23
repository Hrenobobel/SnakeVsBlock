using UnityEngine;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public GameObject StartMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;

    public enum State
    {
        Play,
        Win,
        Lose,
    }
    public State CurrentState { get; private set; }

    public void OnPlayerStart()
    {
        StartMenu.SetActive(false);
        Controls.enabled = true;
    }
    public void OnPlayerDie()
    {
        Controls.enabled = false;
        LoseMenu.SetActive(true);
    }
    public void OnPlayerWin()
    {
        Controls.enabled = false;
        LevelIndex++;
        WinMenu.SetActive(true);
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