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
        ValueText.text = Value.ToString();

        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_Key", (float)Value);

        lastValue = Value;
    }

    private void Update()
    {
        if (lastValue == Value) return;

        ValueText.text = Value.ToString();
        rend.material.SetFloat("_Key", (float)Value);

        lastValue = Value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        player.Stop();

        lastValue = Value;
        for (int i = 0; i < lastValue; i++)
        {
            StartCoroutine(Wait(player));
        }
        //player.Play();
    }

    private IEnumerator Wait(Player player)
    {
        Value--;
        player.LiveDown();
        yield return new WaitForSeconds(1);
        
    }
}
