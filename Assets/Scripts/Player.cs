using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Length;
    public TextMeshPro LengthText;
    public MoveUp moveUp;
    public Controls controls;
    public Game game;

    private SnakeScript SnakeScript;
    private int lastLength;

    void Start()
    {
        LengthText.SetText(Length.ToString());
        lastLength = Length;
        SnakeScript = GetComponent<SnakeScript>();
        controls = GetComponent <Controls>();

        for (int i = 0; i < Length; i++)
        {
            LiveUp();
        }
    }
    
    void Update()
    {
        //if (lastLength == Length) return;

        //LengthText.SetText(Length.ToString());

        if (Input.GetKeyDown(KeyCode.A))
        {
            LiveUp();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LiveDown();
        }
    }
    public void LiveUp()
    {
        Length ++;
        LengthText.SetText(Length.ToString());
        SnakeScript.LengthUp();
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
        if (Length == 0)
        {
            this.gameObject.SetActive(false);
            controls.enabled = false;
        }
        moveUp.Stop();
        LiveDown();
    }
    public void Stop()
    {
        moveUp.Stop();
    }

    public void Play()
    {
        moveUp.Play();
    }
}
