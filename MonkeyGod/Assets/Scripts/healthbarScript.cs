using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthbarScript : MonoBehaviour {

	public RectTransform healthtransform;
	private float catchedY;
	private float minXvalue;

	private float maxXvalue;
	private int currentHealth;
	public int maxHealth;
	public Text helthText;
	public Image visualHealth;

	// Use this for initialization
	void Start () {
	
		catchedY = healthtransform.position.y;
		maxXvalue = healthtransform.position.x;
		minXvalue = healthtransform.position.x - healthtransform.rect.width;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void HandlehealthBar(){

		helthText.text = "Health:" + currentHealth;
		float currentXvalue = MapValues (currentHealth ,0,maxHealth,minXvalue,maxXvalue);
		healthtransform.position = new Vector3 (currentXvalue,catchedY);
		if (currentHealth > maxHealth) {
			visualHealth.color =new Color32((byte)MapValues(currentHealth,maxHealth/2,maxHealth,255,0),255,0,255);
		} else {
			visualHealth.color =new Color32(255,(byte)MapValues(currentHealth,0,maxHealth/2,0,255),0,255);
		}
	}
	private float MapValues(float x,float inMin,float inMax,float outMin,float outMax){

		return(x - inMin) * (outMax -outMin)/(inMax - inMin) +outMin;
	}
}
