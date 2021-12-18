using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMesh Text;
    public int Value;
    public int minValue;
    public int maxValue;

    private Renderer rend;
    private int lastValue;

    private void Awake()
    {
        Value = Random.Range(minValue, maxValue);
        Text.text = Value.ToString();

        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_Key", (float)Value);

        lastValue = Value;
    }

    private void Update()
    {
        if (lastValue == Value) return;

        Text.text = Value.ToString();
        rend.material.SetFloat("_Key", (float)Value);

        lastValue = Value;
    }
}
