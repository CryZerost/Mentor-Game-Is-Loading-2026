using UnityEngine;

public class RandomizerCoin : MonoBehaviour
{
    public GameObject coinObject;
    public Transform[] spawnArea;

    private void Start()
    {
        for (int i = 0; i < spawnArea.Length; i++)
        {
            Instantiate(coinObject, spawnArea[i]);
        }
    }

    private void Update()
    {

    }
}

