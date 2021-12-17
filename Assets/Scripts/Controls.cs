
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Player;
    public float Sensivity;
    public Transform LeftCorner;
    public Transform RightCorner;

    //public Vector3 Force;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Vector3 motion = new Vector3 (delta.x, 0f, 0f);

            Player.transform.position += motion * Sensivity;

            if (Player.transform.position.x < LeftCorner.transform.position.x)
                Player.transform.position = new Vector3(LeftCorner.transform.position.x, 0f, 0f);
            if (Player.transform.position.x > RightCorner.transform.position.x)
                Player.transform.position = new Vector3(RightCorner.transform.position.x, 0f, 0f);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
