using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshPro ValueText;
    public int BlockValue;
    public int minValue;
    public int maxValue;
    public Transform bottom;
    public Transform center;
    public Transform right;
    public Transform left;

    private Renderer rend;

    private void Awake()
    {
        BlockValue = Random.Range(minValue, maxValue);
        rend = GetComponent<Renderer>();

        UpdateValue();
    }

    private void UpdateValue()
    {
        ValueText.text = BlockValue.ToString();
        rend.material.SetFloat("_Key", (float)BlockValue);
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
            player.Stop();
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
            MinusBlockValue(player);
        }
    }
    private void MinusBlockValue(Player player)
    {
        player.Block();

        BlockValue--;

        if (BlockValue == 0)
        {
            Destroy(this.gameObject);
        }
        UpdateValue();

        if (player.PlayerLength >= 0)
            player.Play();
    }
}
