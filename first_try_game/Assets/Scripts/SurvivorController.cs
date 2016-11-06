using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurvivorController : MonoBehaviour {
    public GameObject character;

    public float moveSpeed;
    private Vector3 moveDirection;
    public float turnSpeed;
    private float angle;
	private List<Transform> congaLine = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        moveDirection = Vector3.right;

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 currentPosition = character.transform.position;

        if (Input.GetButton("Fire1"))
        {
            
            Vector3 lookToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            moveDirection = lookToward - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize();
        }
        Vector3 target = moveDirection * moveSpeed + currentPosition;
        transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation =
          Quaternion.Slerp(transform.rotation,
                            Quaternion.Euler(0, 0, targetAngle),
                            turnSpeed * Time.deltaTime);


        /*WASD Movement 
        transform.Rotate(new Vector3(0,0,1)* Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed * -20f);
        
        transform.Translate(new Vector3(1,0,0)*Input.GetAxis("VerticalUp") * Time.deltaTime * moveSpeed, Space.World);
        transform.Translate(new Vector3(1,0,0) * Input.GetAxis("VerticalDown") * Time.deltaTime * moveSpeed * 3f, Space.World);*/
        
        EnforceBounds();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

			Transform followTarget = congaLine.Count == 0 ? transform : congaLine[congaLine.Count-1];
			other.GetComponent<CatController>().JoinConga( followTarget, moveSpeed, turnSpeed );
			congaLine.Add( other.transform );


    }
    private void EnforceBounds()
    {
        // 1
        Vector3 newPosition = transform.position;
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // 2
        float xDist = mainCamera.aspect * mainCamera.orthographicSize;
        float xMax = cameraPosition.x + xDist;
        float xMin = cameraPosition.x - xDist;

        // 3
        if (newPosition.x < xMin || newPosition.x > xMax)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            moveDirection.x = -moveDirection.x;
        }
        // TODO vertical bounds
        float yMax = mainCamera.orthographicSize;

        if (newPosition.y < -yMax || newPosition.y > yMax)
        {
            newPosition.y = Mathf.Clamp(newPosition.y, -yMax, yMax);
            moveDirection.y = -moveDirection.y;
        }

        // 4
        transform.position = newPosition;
    }
	public float getmoveSpeed(){
		Debug.Log ("movespeed");
		return moveSpeed;}
	public float getturnSpeed(){
		Debug.Log ("turnspeed");
		return turnSpeed;}
	public Transform getTransform(){
		Debug.Log ("transform");
		return transform;
	}
}