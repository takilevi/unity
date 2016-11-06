using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate (explosion, other.transform.position, Quaternion.identity);
		Destroy (other.gameObject);
	}
}
