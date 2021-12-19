using TMPro;
using UnityEngine;

public class BonusLives : MonoBehaviour
{
    public TextMeshPro ValueText;
    public int Value;
    public int minValue;
    public int maxValue;

    private void Awake()
    {
        Value = Random.Range(minValue, maxValue);
        ValueText.text = Value.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.LivesUp(Value);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
