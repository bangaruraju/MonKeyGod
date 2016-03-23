using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
//[RequireComponent(typeof (ThirdPersonCharacter))]
	public class ShieldRotateScript : MonoBehaviour {
//		private ThirdPersonUserControl m_Character_User;
//		private Rigidbody coinRigidbody;
//		void Start () {
//			coinRigidbody = GetComponent<Rigidbody> ();
//			m_Character_User = GetComponent<ThirdPersonUserControl>();
//		}
		void Update () {
			int rotation = PlayerPrefs.GetInt ("SHIELD_ROTATE_STATUS");
			if(rotation == 1)
				transform.Rotate (new Vector3 (0, 0, -45) * 0.1f);
		}
	}
}