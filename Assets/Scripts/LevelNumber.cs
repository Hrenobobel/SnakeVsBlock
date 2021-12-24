using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    public Text Text;
    public Game Game;
    
    void Start()
    {
        Text.text = (Game.LevelIndex + 1).ToString();
    }
}
