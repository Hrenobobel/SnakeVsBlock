using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float Speed;
    private Vector3 motion;

    private void Start()
    {
        motion = new Vector3(0, Speed, 0);
    }

    void Update()
    {
        transform.position += motion;
    }
}
