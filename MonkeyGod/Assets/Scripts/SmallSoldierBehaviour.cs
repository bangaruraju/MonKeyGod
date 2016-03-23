using UnityEngine;
using System.Collections;

public class SmallSoldierBehaviour : MonoBehaviour {

	public int speedValue = 2;
	Vector3 SmallSoldiermovement;  
	private Rigidbody SmallSoldierplayerRigidbody;
	bool isGoingLeft = true;
	Vector3 _originalPosition;
	int distance = 5;
	int verticalDistance = 6;
	public bool direction = true;
	public bool isMove = true;
	float distFromStart;
	// Use this for initialization
	void Start () {
		SmallSoldierplayerRigidbody = GetComponent <Rigidbody> ();
		_originalPosition = transform.position;
		SmallSoldierplayerRigidbody.useGravity = false;
//		SmallSoldierplayerRigidbody.transform.Rotate(new Vector3(0,0,0));
	}

//	void OnCollisionEnter(Collision collision) {
//
//		if (collision.transform.tag == "Player") {
//		//	Debug.Log("Game Over");
//			Application.LoadLevel("gameOver");
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		if (isMove) {
			if(this.gameObject.name.Equals("Bat Anim 4(Clone)"))
				distFromStart = transform.position.y - _originalPosition.y;
			else
				distFromStart = transform.position.x - _originalPosition.x;
		//	float distFromStart = transform.position.x - _originalPosition.x;
			float verticalDistFromStart = transform.position.z - _originalPosition.z;
			//Debug.Log (direction + " " + verticalDistFromStart);
			if (isGoingLeft) { 
				if (direction) {
					if(this.gameObject.name.Equals("Bat Anim 4(Clone)"))
						SmallSoldiermovement.Set (0,-1, 0);
					else
						SmallSoldiermovement.Set (-1, 0, 0);
					// Set the movement vector based on the axis input.
				//	SmallSoldiermovement.Set (-1, 0, 0);
					if (distFromStart < -distance)
					{
						SwitchDirection ();
					if(this.gameObject.name.Equals("Bee_Prefab(Clone)"))
						SmallSoldierplayerRigidbody.MoveRotation (Quaternion.Euler(0,90,0));
					}else if(this.gameObject.name.Equals("pumpkin_boy(Clone)")){
//						Debug.Log(this.gameObject.transform.GetChild(0).gameObject.name);
//						this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
						this.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled=false;
						
					}
				
				} else {
					SmallSoldiermovement.Set (0, 0, -1);
					if (verticalDistFromStart < -verticalDistance)
						SwitchDirection ();
				}
				// If gone too far, switch direction
//			if (distFromStart < -distance)
//				SwitchDirection();
//			transform.Translate (Vector3.forward * Time.deltaTime);
				//_transform.Translate (velocity.x * Time.deltaTime, 0, 0);
			} else {
				if (direction) {
					if(this.gameObject.name.Equals("Bat Anim 4(Clone)"))
						SmallSoldiermovement.Set (0, 1, 0);
					else
						SmallSoldiermovement.Set (1, 0, 0f);
					// Set the movement vector based on the axis input.
				//	SmallSoldiermovement.Set (1, 0, 0f);
					if (distFromStart > distance)
					{
						SwitchDirection ();

					if(this.gameObject.name.Equals("Bee_Prefab(Clone)"))
						SmallSoldierplayerRigidbody.MoveRotation (Quaternion.Euler(0,-90,0));
					}else if(this.gameObject.name.Equals("pumpkin_boy(Clone)")){
//						this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
//						try{
							this.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled=true;
//						}catch{
//						}

					}

				} else {
					SmallSoldiermovement.Set (0, 0, 1);
					if (verticalDistFromStart > verticalDistance)
						SwitchDirection ();
				}
				// If gone too far, switch direction
//			if (distFromStart > distance)
//				SwitchDirection();
//			transform.Translate (Vector3.back * Time.deltaTime);
				//_transform.Translate (-velocity.x * Time.deltaTime, 0, 0);
			}

//		// Set the movement vector based on the axis input.
//		SmallSoldiermovement.Set (1, 0, 0f);
		
			// Normalise the movement vector and make it proportional to the speed per second.
			SmallSoldiermovement = SmallSoldiermovement.normalized * speedValue * Time.deltaTime;
		
			// Move the player to it's current position plus the movement.
			SmallSoldierplayerRigidbody.MovePosition (transform.position + SmallSoldiermovement);

		}
	}

	void SwitchDirection()
	{
		isGoingLeft = !isGoingLeft;
		//TODO: Change facing direction, animation, etc
	}
}

