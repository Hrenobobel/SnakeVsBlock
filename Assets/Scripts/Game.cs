using UnityEngine;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public GameObject StartMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;
    public GameObject GameUI;
    public int MaxLevel;
    public Player Player;

    private void Start()
    {
        StartMenu.SetActive(true);
        GameUI.SetActive(false);
        LoseMenu.SetActive(false);
        WinMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnPlayerStart();
    }

    public void OnPlayerStart()
    {
        StartMenu.SetActive(false);
        GameUI.SetActive(true);
        Player.Play();
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
        if (LevelIndex > MaxLevel-1)
            LevelIndex = 0;
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