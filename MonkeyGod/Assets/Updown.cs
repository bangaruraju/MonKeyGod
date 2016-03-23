using UnityEngine;
using System.Collections;

public class Updown : MonoBehaviour {
	float maxUpAndDown=.2f;
	float speed =80f;
	float angle=0f;
	float toDegrees = Mathf.PI / 180;
//
	void  Update()
	{
		int Swith=PlayerPrefs.GetInt ("Swith");
		if (Swith == 1) {
			angle += speed * Time.deltaTime;
			if (angle > 360)
				angle -= 360;
			float f = maxUpAndDown * Mathf.Sin (angle * toDegrees);
//			float fss=transform.position.y ;
//			transform.localPosition.y = f;
			transform.Translate (new Vector3 (0.0f, f, 0.0f), Space.World);
//			fss = f;
		}
	}


}
