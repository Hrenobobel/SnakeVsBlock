using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject Head;
    public GameObject Unit;
    public float UnitDiameter;

    private List<GameObject> SnakeElementList = new List<GameObject>();
    private List<Rigidbody> RigidBodyList = new List<Rigidbody>();
    private Vector3 _previousBodyPart;
    private Vector3 _currentBodyPart;
    private float _distance;
    public float Power;

    private void Awake()
    {
        SnakeElementList.Add(Head);
        RigidBodyList.Add(Head.gameObject.GetComponent<Rigidbody>());
    }

    private void FixedUpdate()
    {
        for (int i = 1; i < SnakeElementList.Count - 1; i++)
        {
            _currentBodyPart = SnakeElementList[i].transform.position;
            _previousBodyPart = SnakeElementList[i - 1].transform.position;

            _distance = Vector3.Distance(_previousBodyPart, _currentBodyPart);

            if (_distance > UnitDiameter)
            {
                Vector3 delta = _previousBodyPart - _currentBodyPart;
                Vector3 motion = new Vector3(delta.x, delta.y, 0f);

                RigidBodyList[i].AddForce(motion * Power, ForceMode.Impulse);
            }
        }
    }

    public void LengthUp()
    {
        Vector3 position = new Vector3((SnakeElementList[SnakeElementList.Count - 1]).transform.position.x, (SnakeElementList[SnakeElementList.Count - 1]).transform.position.y - 0.9f, 0f);
        GameObject NewUnit = Instantiate(Unit, position, Quaternion.identity, transform);
        SnakeElementList.Add(NewUnit);
        RigidBodyList.Add(NewUnit.gameObject.GetComponent<Rigidbody>());
    }
    public void LengthDown()
    {
        Destroy(SnakeElementList[SnakeElementList.Count - 1].gameObject);
        SnakeElementList.RemoveAt(SnakeElementList.Count - 1);
    }
}
