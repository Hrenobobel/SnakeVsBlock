using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Length = 5;
    public TextMeshPro LengthText;
    public MoveUp moveUp;

    private SnakeScript SnakeScript;

    void Start()
    {
        LengthText.SetText(Length.ToString());

        SnakeScript = GetComponent<SnakeScript>();

        for (int i = 0; i < Length; i++)
            SnakeScript.LengthUp();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            LengthText.SetText(Length.ToString());
            SnakeScript.LengthUp();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            LengthText.SetText(Length.ToString());
            SnakeScript.LengthDown();
        }
    }
    public void LivesUp(int number)
    {
        Length += number;
        LengthText.SetText(Length.ToString());
        for (int i = 0; i < number; i++)
            SnakeScript.LengthUp();
    }
    public void LiveDown()
    {
        Length--;
        LengthText.SetText(Length.ToString());
        SnakeScript.LengthDown();
    }

    public void Stop()
    {
        moveUp.Stop();
        Debug.Log("STOP");
    }

    public void Play()
    {
        moveUp.Play();
    }
}
