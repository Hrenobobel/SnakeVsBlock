using System.Collections;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshPro ValueText;
    public int Value;
    public int minValue;
    public int maxValue;
    public Player player;

    private Renderer rend;
    private int lastValue;

    private void Awake()
    {
        Value = Random.Range(minValue, maxValue);
        rend = GetComponent<Renderer>();

        UpdateValue();
    }

    private void UpdateValue()
    {
        ValueText.text = Value.ToString();
        rend.material.SetFloat("_Key", (float)Value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        lastValue = Value;
        for (int i = 0; i < lastValue; i++)
        {
            player.Block();
            StartCoroutine(Wait());
        }
        //player.Play();
    }

    private IEnumerator Wait()
    {
        Value --;
        UpdateValue();
        Debug.Log("2 seconds");
        yield return new WaitForSeconds(1f);
    }
}
