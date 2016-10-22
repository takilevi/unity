using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float speed = -1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
