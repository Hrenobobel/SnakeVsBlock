using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerLength;
    public TextMeshPro LengthText;
    public MoveUp moveUp;
    public Game game;
    public GameObject LiveDownParticle;
    public AudioSource PlayerAudio;
    public AudioClip LoseAudio;
    public AudioClip LivesAudio;
    public AudioClip WinAudio;

    private SnakeScript SnakeScript;
    private int lastLength;

    void Start()
    {
        SnakeScript = GetComponent<SnakeScript>();
        UpdateLengthText();
        for (int i = 0; i < PlayerLength; i++)
            SnakeScript.LengthUp();
    }

    private void UpdateLengthText()
    {
        LengthText.SetText(PlayerLength.ToString());
    }

    public void LivesUp(int number)
    {
        PlayerAudio.PlayOneShot(LivesAudio, 0.5f);
        PlayerLength += number;
        UpdateLengthText();
        for (int i = 0; i < number; i++)
            SnakeScript.LengthUp();
    }
    public void LiveDown()
    {
        PlayerAudio.Play();
        UpdateLengthText();
        SnakeScript.LengthDown();
    }

    public void Block()
    {
        PlayerLength--;
        if (PlayerLength < 0)
        {
            PlayerAudio.PlayOneShot(LoseAudio, 0.25f);
            game.OnPlayerDie();
        }
        else LiveDown();
    }

    public void Stop()
    {
        moveUp.Stop();
        Instantiate(LiveDownParticle, transform);
    }

    public void Play()
    {
        moveUp.Play();
    }

    public void ReachedFinish()
    {
        PlayerAudio.PlayOneShot(WinAudio, 0.5f);
        moveUp.Stop();
        game.OnPlayerWin();
    }
}
