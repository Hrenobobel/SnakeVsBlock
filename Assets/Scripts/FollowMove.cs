using UnityEngine;

public class FollowMove : MonoBehaviour
{
    public Player Player;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
    }
}
