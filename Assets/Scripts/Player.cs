using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Length = 5;
    public TextMeshPro LengthText;
    public MoveUp moveUp;

    private SnakeScript SnakeScript;
    private int lastLength;

    void Start()
    {
        LengthText.SetText(Length.ToString());
        lastLength = Length;
        SnakeScript = GetComponent<SnakeScript>();

        for (int i = 0; i < Length; i++)
            SnakeScript.LengthUp();
    }

    void Update()
    {
        if (lastLength == Length) return;

        LengthText.SetText(Length.ToString());

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

    public void Block()
    {
        moveUp.Stop();
        LiveDown();
        if (Length < 0)
            Debug.Log("Game Over");
    }

    public void Play()
    {
        moveUp.Play();
    }
}
