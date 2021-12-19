using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;

    private float StartY;

    private void Start()
    {
        StartY = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Player.transform.position.y + StartY, transform.position.z);
    }
}
