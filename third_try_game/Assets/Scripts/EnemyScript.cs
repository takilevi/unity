using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed;
	public GameObject survival;
	private Transform player;
	void Start(){
		player = GameObject.Find("survivor").transform;
	}
	void FixedUpdate(){
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), 
		                       (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;

		transform.eulerAngles = new Vector3 (0, 0, z);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * speed);
	}
	IEnumerator OnBecameInvisible() {
		Debug.Log ("lement a kepernyorol");
		
		yield return new WaitForSeconds(3.0F);
		if (IsTargetVisible (gameObject)) {
			print ("nem pusztult el");
		} else {
			
			Destroy( gameObject ); 
			print("elpusztult");
		}
	}
	bool IsTargetVisible(GameObject go)
	{
		var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		var point = go.transform.position;
		foreach (var plane in planes)
		{
			if (plane.GetDistanceToPoint(point) < 0)
				return false;
		}
		return true;
	}


}
