using UnityEngine;
using System.Collections;

public class CollectibleCreator : MonoBehaviour {

	public float minSpawnTime = 10f; 
	public float maxSpawnTime = 20f;
	public GameObject collect1;


	void Start () {
		Invoke("SpawnCollectible",minSpawnTime);
	}
	void SpawnCollectible()
	{
		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 2f;
		float yMax = camera.orthographicSize-0.1f;

		Vector3 enemyPos = 
			new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
			            Random.Range(-yMax, yMax),
			            collect1.transform.position.z);
		
		Instantiate(collect1, enemyPos, Quaternion.identity);
		
		Invoke("SpawnCollectible", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
