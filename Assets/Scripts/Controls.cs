using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Player;
    public float Sensivity;
    public Transform LeftCornerTransform;
    public Transform RightCornerTransform;

    private Vector3 _previousMousePosition;
    private float LeftCorner;
    private float RightCorner;

    private void Awake()
    {
        LeftCorner = LeftCornerTransform.transform.position.x;
        RightCorner = RightCornerTransform.transform.position.x;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Vector3 motion = new Vector3 (delta.x, 0f, 0f);

            Player.transform.position += motion * Sensivity;

            if (Player.transform.position.x < LeftCorner)
                Player.transform.position = new Vector3(LeftCorner, Player.transform.position.y, Player.transform.position.z);
            if (Player.transform.position.x > RightCorner)
                Player.transform.position = new Vector3(RightCorner, Player.transform.position.y, Player.transform.position.z);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
