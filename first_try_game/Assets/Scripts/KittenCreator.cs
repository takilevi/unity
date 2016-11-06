using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KittenCreator : MonoBehaviour {

    //1
    public float minSpawnTime = 0.75f;
    public float maxSpawnTime = 3f;
	public GameObject catPrefab;
	//private List<Transform> enemyLine = new List<Transform>();

    //2    
    void Start()
    {
        Invoke("SpawnCat", minSpawnTime);
    }

    //3
    void SpawnCat()
    {
		/*GameObject go = GameObject.Find("rifle");
		SurvivorController player = (SurvivorController) go.GetComponent(typeof(SurvivorController));

		Transform followTarget = enemyLine.Count == 0 ? player.getTransform() : enemyLine[enemyLine.Count-1];
		catPrefab.GetComponent<CatController>().AttackPlayer( followTarget, player.getmoveSpeed(), player.getturnSpeed() );
		*/

		// 1
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 2f;
		float yMax = camera.orthographicSize;// - 0.5f;
		
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
