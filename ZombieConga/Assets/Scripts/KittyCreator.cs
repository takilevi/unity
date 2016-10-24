using UnityEngine;

public class KittyCreator : MonoBehaviour
{
    //1
    public float minSpawnTime = 0.75f;
    public float maxSpawnTime = 2f;
    public GameObject catPrefab;
    //2    
    void Start()
    {
        Invoke("SpawnCat", minSpawnTime);
    }

    //3
    void SpawnCat()
    {
        Debug.Log("TODO: Birth a cat at " + Time.timeSinceLevelLoad);
        Invoke("SpawnCat", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
