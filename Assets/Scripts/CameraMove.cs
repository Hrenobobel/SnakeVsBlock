using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Player Player;

    private float lastYposition;
    private float StartY;

    private void Start()
    {
        StartY = transform.position.y;
        lastYposition = Player.transform.position.y;
    }
    void Update()
    {
        if (lastYposition > Player.transform.position.y) return;
        transform.position = new Vector3(transform.position.x, Player.transform.position.y + StartY, transform.position.z);
        lastYposition = Player.transform.position.y;
    }
}
