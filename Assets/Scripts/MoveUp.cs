using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float Speed;
    public Game game;

    private Vector3 motion;

    private void Start()
    {
        motion = new Vector3(0, Speed, 0);
    }

    private void Update()
    {
        transform.position += motion;
    }

    public void Stop()
    {
        motion = new Vector3(0, 0, 0);
    }

    public void Play()
    {
        motion = new Vector3(0, Speed, 0);
    }
}
