	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;

	public class anotherHealth : MonoBehaviour {

		public float max_health =500f;
		public float cur_health = 0f;
		public GameObject healthBar;
		public Text healthtext;
		// Use this for initialization
		void Start () {
	//		PlayerPrefs.SetFloat ("HEALTH",500);
			cur_health = max_health;
			healthtext.text = "  :   " + PlayerPrefs.GetFloat("HEALTH");

			cur_health = PlayerPrefs.GetFloat ("HEALTH");
			if (cur_health <= 0) {
				PlayerPrefs.SetFloat ("HEALTH",500);
				cur_health=500;
			}
	//		mainhealth = cur_health;
	//		StartCoroutine(JumpUp());
			decreaseHealth ();
	//				Invoke ("SetHealthBar",1f);
	//		InvokeRepeating ("decreaseHealth", 1f, 1f);

		}
	//	void SetHealth(float aNum){
	//		 aNum = aNum / max_health;
	//		healthBar.transform.localScale = new Vector3 (aNum, healthBar.transform.localScale.y, transform.localScale.z);
	//		if (aNum <= 0) {
	//			healthtext.text = "Health : " + "0";
	//		} else {
	//			healthtext.text = "Health : " + aNum;
	//		}
	//	}
		// Update is called once per frame

		public static float mainhealth=0;
		void Update () {
			cur_health = PlayerPrefs.GetFloat ("HEALTH");

			decreaseHealth ();
		}

		void decreaseHealth(){

	//		if (PlayerPrefs.GetFloat ("HEALTH") == 500) {
	//			cur_health -=1;
	//		}else
	//		cur_health +=PlayerPrefs.GetFloat ("HEALTH");
				float calc_health = cur_health / max_health;
				SetHealthBar (calc_health);
				if (cur_health == 0) {
					cur_health = 0;
	//			Application.LoadLevel("gameOver");
					healthBar.transform.localScale = new Vector3 (0f, 0f, 0f);
					healthtext.text = " : "+cur_health;
					healthtext.color = Color.red;
	//				StartCoroutine(JumpUp());
				}

			if(mainhealth != cur_health){
	//			StartCoroutine(JumpUp());
			}

		}
		IEnumerator JumpUp() {
			yield return new WaitForSeconds(0.2f);
			healthtext.color = Color.white;
			yield return new WaitForSeconds(0.2f);
			healthtext.color = Color.red;
			yield return new WaitForSeconds(0.2f);
			healthtext.color = Color.white;
			yield return new WaitForSeconds(0.2f);
			healthtext.color = Color.red;
			mainhealth = cur_health;
		}

		public void SetHealthBar(float myHealth){

			healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, transform.localScale.z);
			if (cur_health <= 0) {
				healthtext.text = "  :   " + "0";
			} else {
				healthtext.text = "  :   " + cur_health;
				PlayerPrefs.SetFloat ("HEALTH",cur_health);
			}

		}
	}
