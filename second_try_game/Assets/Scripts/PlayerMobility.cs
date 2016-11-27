using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	Animator anim;
	void Start(){
		anim = GetComponent<Animator>();
	}
	void Update(){
		if (Input.GetAxis("Fire1") != 0) {
			Debug.Log("clicked");
			anim.SetTrigger("Attack");}
		if (Input.GetKey(KeyCode.R)) {
			Debug.Log("reloaded");
			anim.SetTrigger("Reload");
		}
	}
	void FixedUpdate () {

		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z+90f);
		GetComponent<Rigidbody2D>().angularVelocity = 0;

		float input = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", Mathf.Abs (input));
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed * input);

		//EnforceBounds();
	}
	private void EnforceBounds()
	{
		Vector3 moveDirection = gameObject.transform.right;
		// 1
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		
		// 2
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;
		
		// 3
		if ( newPosition.x < xMin || newPosition.x > xMax ) {
			newPosition.x = Mathf.Clamp( newPosition.x, xMin, xMax );
			moveDirection.x = -moveDirection.x;
		}
		float yMax = mainCamera.orthographicSize;
		
		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			moveDirection.y = -moveDirection.y;
		}
		
		// 4
		transform.position = newPosition;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("auch");
		Debug.Log (other.gameObject.name);
		Application.LoadLevel("game_over_scene");

	}
}
