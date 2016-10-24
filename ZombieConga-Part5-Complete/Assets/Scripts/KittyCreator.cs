using UnityEngine;

public class KittyCreator: MonoBehaviour {
	//1
	public float minSpawnTime = 0.75f; 
	public float maxSpawnTime = 2f; 

	public GameObject catPrefab;

	//2    
	void Start () {
		Invoke("SpawnCat",minSpawnTime);
	}
	
	//3
	void SpawnCat()
	{
		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		// 2
		Vector3 catPos = 
			new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
			            Random.Range(-yMax, yMax),
			            catPrefab.transform.position.z);
		
		// 3
		Instantiate(catPrefab, catPos, Quaternion.identity);

		Invoke("SpawnCat", Random.Range(minSpawnTime, maxSpawnTime));
	}
}