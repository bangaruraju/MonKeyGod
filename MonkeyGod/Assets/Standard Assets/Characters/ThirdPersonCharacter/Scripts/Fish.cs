using UnityEngine;
using System.Collections;
public class Fish : MonoBehaviour {
	
	public Transform wayPoint;
	private Vector3 wayPointPos;
	
	private bool tagg;
	private bool tagg1;
	public bool fishTag;
	Animation anim;
	public static bool tagg2 = false;


	
//	public Transform[] path;
//	public float speed = 0.5f;
//	public float reachDist = 1.0f;
//	public int currentPoint = 0;
	
	private int faceDirection = 0;
	
	
	// Use this for initialization
	void Start () {
		tagg = false;
		tagg1 = false;
		fishTag = false;
		
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
		try{
			if (fishTag) {
				
				wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, wayPointPos, 1.5f * Time.deltaTime);
				
				if (wayPoint.transform.position.x < transform.position.x) {
					
					if (!tagg1) {
						
						if(faceDirection == 2){
							faceDirection = 1;
							transform.Rotate(0,180,0);
							tagg1 = true;
							tagg = false;
						}
						else if(faceDirection == 0){
							faceDirection = 1;
							transform.Rotate(0,180,0);
							tagg1 = true;
							tagg = false;
						}
						tagg2 = true;
					}
				}
				else {
					
					if (!tagg) {
						if(faceDirection == 1){
							faceDirection = 0;
							transform.Rotate(0,180,0);
							tagg1 = false;
							tagg = true;
						}
						else if(faceDirection == 0){
							faceDirection = 2;
						}
						tagg2 = false;
					}
				}
			} 
//			else {
//				
//				if(faceDirection == 1){
//					transform.Rotate(0,180,0);
//					faceDirection = 0;
//				}
//				
//				tagg1 = false;
//				tagg = false;
//				
//				float dist = Vector3.Distance (path [currentPoint].position, transform.position);
//				transform.position = Vector3.MoveTowards (transform.position, path [currentPoint].position, Time.deltaTime * speed);
//				
//				if (dist <= reachDist)
//					currentPoint++;
//				
//				if (currentPoint >= path.Length)
//					currentPoint = 0;
//			}
		}
		catch{
		}
	}
	
	IEnumerator SoundsRepeat() {
		anim.Play("FishEat");
		yield return new WaitForSeconds(anim.clip.length);
		anim.Play("FishMove");
	}
}
