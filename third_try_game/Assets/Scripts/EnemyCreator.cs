using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

	//1
	public float minSpawnTime = 0.3f; 
	public float maxSpawnTime = 2f; 
	public GameObject enemyPrefab;

	//2    
	void Start () {
		Invoke("SpawnEnemy",minSpawnTime);
	}

	//3
	void SpawnEnemy()
	{
		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 2f;
		float yMax = camera.orthographicSize - 0.2f;
		
		// 2
		Vector3 enemyPos = 
			new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
			            Random.Range(-yMax, yMax),
			            enemyPrefab.transform.position.z);
		
		// 3
		Instantiate(enemyPrefab, enemyPos, Quaternion.identity);

		Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
