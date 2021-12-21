using System.Collections;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshPro ValueText;
    public int Value;
    public int minValue;
    public int maxValue;
    public Transform bottom;
    public Transform center;
    public Transform right;
    public Transform left;

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
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;

        if (player.transform.position.y > bottom.transform.position.y)
        {
            if (player.transform.position.x > center.transform.position.x)
                player.transform.position = new Vector3(right.transform.position.x, player.transform.position.y, player.transform.position.z);
            else if (player.transform.position.x < center.transform.position.x)
                player.transform.position = new Vector3(left.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
        else
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.1f, player.transform.position.z);
            player.Stop();
            lastValue = Value;
            StartCoroutine(Wait(player));
        }
    }

    private IEnumerator Wait(Player player)
    {
        Value --;
        player.Block();
        UpdateValue();
        yield return new WaitForSeconds(0.1f);
        
        if (Value == 0)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        player.Play();
    }
}
