using UnityEngine;

public class DownMove : MonoBehaviour
{
    private Vector3 motion;

    private void Start()
    {
        motion = new Vector3(0, - Controls.FallSpeed, 0);
    }

    void Update()
    {
        transform.position += motion;
    }
}
