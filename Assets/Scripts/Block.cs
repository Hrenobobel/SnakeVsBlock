using System.Collections;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshPro ValueText;
    public int Value;
    public int minValue;
    public int maxValue;
    private Player player;

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

        player.Stop();
        lastValue = Value;
        StartCoroutine(Wait(player));
    }
    
    private IEnumerator Wait(Player player)
    {
        int i = lastValue;
        while (i > 0)
        {
            Value --;
            UpdateValue();
            player.Block();
            yield return new WaitForSeconds(0.1f);
            i--;
        }
        this.gameObject.SetActive(false);
        player.Play();        
        Destroy(this.gameObject);
    }
}
