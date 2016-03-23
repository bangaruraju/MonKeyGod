using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoard : MonoBehaviour {

	public	void OnOutsideOrCloseOrHomeclick()
	{
	//	PlayerPrefs.SetInt ("UI_DESABLE",0);
//		PlayerPrefs.SetInt("isGui",0);
		Destroy (this.gameObject);
	}

}
