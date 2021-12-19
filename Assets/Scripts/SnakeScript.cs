using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public Transform Head;
    public Transform Unit;
    public float UnitDiameter;

    private List<Transform> snakeUnit = new List<Transform>();
    private List<Vector3> unitsPosition = new List<Vector3>();
    
    private void Awake()
    {
        unitsPosition.Add(Head.position);
    }

    private void Update()
    {
        float offset = ((Vector3)Head.position - unitsPosition[0]).magnitude;

        if (offset > UnitDiameter)
        {
            Vector3 direction = ((Vector3)Head.position - unitsPosition[0]).normalized;

            unitsPosition.Insert(0, unitsPosition[0] + direction * UnitDiameter);
            unitsPosition.RemoveAt(unitsPosition.Count - 1);

            offset -= UnitDiameter;
        }

        for (int i = 0; i < snakeUnit.Count; i++)
        {
            snakeUnit[i].position = Vector3.Lerp(unitsPosition[i + 1], unitsPosition[i], offset / UnitDiameter);
        }
    }

    public void LengthUp()
    {
        Vector3 position = new Vector3((unitsPosition[unitsPosition.Count - 1]).x, (unitsPosition[unitsPosition.Count - 1]).y - UnitDiameter, (unitsPosition[unitsPosition.Count - 1]).z);
        Transform NewUnit = Instantiate(Unit, position, Quaternion.identity, transform);
        snakeUnit.Add(NewUnit);
        unitsPosition.Add(NewUnit.position);
    }
    public void LengthDown()
    {
        Destroy(snakeUnit[0].gameObject);
        snakeUnit.RemoveAt(0);
        unitsPosition.RemoveAt(1);
    }

}
