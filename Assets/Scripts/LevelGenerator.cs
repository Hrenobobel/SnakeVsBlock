using Random = System.Random;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] BlockBoxPrefabs;
    public GameObject FinishObject;
    public GameObject BonusLive;
    public int MinBlockBoxNumber;
    public int MaxBlockBoxNumber;
    public float FirstElementDistance;
    public float DistanceBetweenElements;
    public float LeftBorder;
    public float RightBorder;
    public Game Game;

    private float _LevelDistance;

    private void Awake()
    {
        int LevelIndex = Game.LevelIndex;
        Random random = new Random(LevelIndex);

        _LevelDistance = DistanceBetweenElements - LevelIndex * DistanceBetweenElements/10;

        int BlockBoxCount = RandomRange(random, MinBlockBoxNumber, MaxBlockBoxNumber);

        for (int i = 0; i < BlockBoxCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, BlockBoxPrefabs.Length);
            GameObject BlockBoxPrefab = BlockBoxPrefabs[prefabIndex];
            GameObject BlockBox = Instantiate(BlockBoxPrefab, transform);
            BlockBox.transform.position = CalculateBlockBoxPosition(i);

            GameObject Bonus = Instantiate(BonusLive, transform);
            Bonus.transform.position = CalculateBonusPosition(i, random);
        }
        GameObject Finish = Instantiate(FinishObject, transform);
        Finish.transform.position = CalculateBlockBoxPosition(BlockBoxCount);
    }

    private int RandomRange(Random random, int min, int maxExlusive)
    {
        int number = random.Next();
        int length = maxExlusive - min;
        number %= length;
        return min + number;
    }
    private float RandomRange(Random random, float min, float maxExlusive)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, maxExlusive, t);
    }

    private Vector3 CalculateBlockBoxPosition(int BlockBoxIndex)
    {
        return new Vector3(0, FirstElementDistance + _LevelDistance * BlockBoxIndex, 0);
    }
    private Vector3 CalculateBonusPosition(int BlockBoxIndex, Random random)
    {
        float BonusX = RandomRange(random, LeftBorder, RightBorder);
        float BonusY = FirstElementDistance + _LevelDistance * BlockBoxIndex + _LevelDistance / 2;
        return new Vector3(BonusX, BonusY, 0);
    }
}