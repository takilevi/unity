using UnityEngine;

public class CatUpdater : MonoBehaviour {
	
	private CatController catController;
	
	// Use this for initialization
	void Start () {
		catController = transform.parent.GetComponent<CatController>();  
	}
	
	void UpdateTargetPosition()
	{
		catController.UpdateTargetPosition();
	}

	void GrantCatTheSweetReleaseOfDeath()
	{
		Destroy( transform.parent.gameObject );
	}

	void OnBecameInvisible() {
		catController.OnBecameInvisible();
	}
}