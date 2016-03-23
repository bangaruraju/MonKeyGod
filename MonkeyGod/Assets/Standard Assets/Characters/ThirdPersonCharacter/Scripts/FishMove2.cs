using UnityEngine;
using System.Collections;

public class FishMove2 : MonoBehaviour {
	
	
	public Transform[] path;
	public float speed = 1.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float dist = Vector3.Distance (path [currentPoint].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, path [currentPoint].position, Time.deltaTime * speed);
		
		
		if (dist <= reachDist)
			currentPoint++;
		
		if (currentPoint >= path.Length)
			currentPoint = 0;
		
	}
}
