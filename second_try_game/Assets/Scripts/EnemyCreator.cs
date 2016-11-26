using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

	//1
	public float minSpawnTime = 0.3f; 
	public float maxSpawnTime = 2f; 
	//private GameObject enemyPrefab;
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
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
		float xRange = camera.aspect * camera.orthographicSize * 3f;
		float yMax = camera.orthographicSize;
		
		//Random rnd = new Random();
		int enemy = Random.Range(1, 5);
		Debug.Log (enemy);
		if (enemy == 1) {

			Vector3 enemyPos = 
			new Vector3(cameraPos.x-0.2f + Random.Range(xMax - xRange, xMax),
			            Random.Range(-yMax, yMax),
			            enemyPrefab1.transform.position.z);
		
			Instantiate(enemyPrefab1, enemyPos, Quaternion.identity);

			Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
		}
		if (enemy == 2) {
			Vector3 enemyPos = 
				new Vector3(cameraPos.x-0.2f + Random.Range(xMax - xRange, xMax),
				            Random.Range(-yMax, yMax),
				            enemyPrefab2.transform.position.z);
			
			Instantiate(enemyPrefab2, enemyPos, Quaternion.identity);
			
			Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
		}
		if (enemy == 3) {
			Vector3 enemyPos = 
				new Vector3(cameraPos.x+0.2f + Random.Range(xMax - xRange, xMax),
				            Random.Range(-yMax, yMax),
				            enemyPrefab3.transform.position.z);
			
			Instantiate(enemyPrefab3, enemyPos, Quaternion.identity);
			
			Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
		}
		if (enemy == 4) {
			Vector3 enemyPos = 
				new Vector3(cameraPos.x+0.2f + Random.Range(xMax - xRange, xMax),
				            Random.Range(-yMax, yMax),
				            enemyPrefab4.transform.position.z);
			
			Instantiate(enemyPrefab4, enemyPos, Quaternion.identity);
			
			Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
		}
	}
}
