using UnityEngine;
using System.Collections;


public class CatController : MonoBehaviour {
	private Transform followTarget;
	private float moveSpeed; 
	private float turnSpeed;
	private Vector3 targetPosition;

	void Update(){
		//2
		Vector3 currentPosition = transform.position;
		Vector3 moveDirection = targetPosition - currentPosition;
		//Vector3 moveDirection = followTarget.position - currentPosition;
		
		//3
		float targetAngle = 
			Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp( transform.rotation, 
		                                      Quaternion.Euler(0, 0, targetAngle), 
		                                      turnSpeed * Time.deltaTime );
		
		//4
		float distanceToTarget = moveDirection.magnitude;
		if (distanceToTarget > 0)
		{
			//5
			if ( distanceToTarget > moveSpeed )
				distanceToTarget = moveSpeed;
			
			//6
			moveDirection.Normalize();
			Vector3 target = moveDirection * distanceToTarget + currentPosition;
			transform.position = 
				Vector3.Lerp(currentPosition, target, moveSpeed * Time.deltaTime);
		}
		
	}
    void GrantCatTheSweetReleaseOfDeath()
    {
        DestroyObject(gameObject);
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
	public void JoinConga( Transform followTarget, float moveSpeed, float turnSpeed ) {
		
		//2
		this.followTarget = followTarget;
		this.moveSpeed = moveSpeed/1.5f;
		this.turnSpeed = turnSpeed/2.8f;
		

		targetPosition = followTarget.position;
		//4
		//Collider2D.enabled = false;

	}
	void UpdateTargetPosition()
	{
		targetPosition = followTarget.position;
	}
	/*public void AttackPlayer( Transform followTarget, float moveSpeed, float turnSpeed ) {
		
		//2
		this.followTarget = followTarget;
		this.moveSpeed = moveSpeed/1.8f;
		this.turnSpeed = turnSpeed/2.5f;

	}*/

}
