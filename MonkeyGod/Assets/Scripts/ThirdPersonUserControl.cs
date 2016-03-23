using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
[RequireComponent(typeof (ThirdPersonCharacter))]
//[RequireComponent(typeof (playerBehaviour))]
public class ThirdPersonUserControl : MonoBehaviour
{
	[HideInInspector]
	public bool SlidingStatus = false;
	public static string mushroomdirection = "MUSHROOMDIRECTION";
	
	// ----------------------
	// Controller Variable 
	// ----------------------
	
	public	TouchController	ctrl;
	
	
	
	// ----------------------
	// Constants
	// ----------------------
	
	public const int STICK_WALK	= 0;
	public const int ZONE_PAUSE	= 0;
	public const int ZONE_RELOAD	= 0;
	
	// ----------------------
	// Update()
	// ----------------------
	
	
	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;
	private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
	
	public static string ShieldRotateStatus = "SHIELD_ROTATE_STATUS";



	private TouchStick walkStick;
	//private int uiDisable;

	private void Start()
	{
		
		PlayerPrefs.SetFloat (mushroomdirection,0);
		//            // get the transform of the main camera
		//            if (Camera.main != null)
		//            {
		//                m_Cam = Camera.main.transform;
		//            }
		//            else
		//            {
		//                Debug.LogWarning(
		//                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
		//                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		//            }
		
		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCharacter>();

		walkStick = this.ctrl.GetStick (STICK_WALK);

	}
	
	
	private void Update()
	{

		if (!m_Jump)
		{
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}

		if(m_Character.DisableTouchStick){

			walkStick.Disable(true);
			m_Character.EnableTouchStick = false;
		}
		if(m_Character.EnableTouchStick){

			walkStick.Enable(true);
		}
	}
	
	
	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		//				if (!m_Character.JetPackStatus) {
		float h = CFInput.GetAxis ("Horizontal");
		float v = CFInput.GetAxis ("Vertical");
		PlayerPrefs.SetFloat (mushroomdirection, h);
		v = 0.0f;
		
		//			m_Move = h * Vector3.right + v * Vector3.up;
		
		//0 TRUE 1 FALSE
		int backrestrict = PlayerPrefs.GetInt ("BACKRESTRICT");
		//			Debug.Log ("backkkkkkkkkkk"+backrestrict);
		
		if (backrestrict == 1) {

			//				Debug.Log("h valueee" +h);
			if (h < 0.0f) {

				h = 0.0f;
				
				//m_Move = new Vector3(0,0,0);
				m_Character.Move (m_Move, false, false);
				m_Character.playerVelocityZero ();
				return;
			}
			
		}
		
		if (this.ctrl != null) {

			int uiDisable = PlayerPrefs.GetInt ("UI_DESABLE");
	
			if(uiDisable==0){
				Time.timeScale =1;
				walkStick.Enable(true);
			} else if(uiDisable == 2)
			{
				PlayerPrefs.SetInt("walkStickStatus",0);
				walkStick.Disable(true);
			}else {
				walkStick.Disable(true);
				PlayerPrefs.SetInt("walkStickStatus",0);
				Time.timeScale =0;
			}
			
			if (walkStick.JustPressed ()) {
				PlayerPrefs.SetInt("walkStickStatus",1);
				//					walkStick.Disable(true);
				//					walkStick.Enable(true);
				// Debug.Log("SDHAKAR JustPressed ");
			} else if (walkStick.GetKey (KeyCode.UpArrow) && walkStick.GetKey (KeyCode.LeftArrow)) {
				//					Debug.Log("left Upper");
				//					if(m_Character.isMovingOnRope)
				//						return;
				//					if(m_Character.isMovingOnLog)
				//						return;
				PlayerPrefs.SetInt("walkStickStatus",1);
				if(m_Character.swimStatus)
					m_Character.swimUpMovingAnim();
				else if(m_Character.swimUpStatus){
					m_Character.swimUpClimbingLeftAnim();
				}
				if (m_Character.JetPackStatus)
					return;
				m_Jump = true;
				m_Character.jumpDirectionValue = -10.0f;
				moveTrasfer (h, v);
				PlayerPrefs.SetInt ("PathRemovalLEFT", 1);
				return;
				
			} else if (walkStick.GetKey (KeyCode.UpArrow) && walkStick.GetKey (KeyCode.RightArrow)) {
				//					Debug.Log("right Upper");
				//					if(m_Character.isMovingOnRope)
				//						return;
				//					if(m_Character.isMovingOnLog)
				//						return;
				PlayerPrefs.SetInt("walkStickStatus",1);
				if(m_Character.swimStatus)
					m_Character.swimUpMovingAnim();
				else if(m_Character.swimUpStatus){
					m_Character.swimUpClimbingRightAnim();
				}  
				if (m_Character.JetPackStatus)
					return;
				m_Jump = true;
				// m_Character.jumpDirection();
				m_Character.jumpDirectionValue = 10.0f;
				moveTrasfer (h, v);
				return;
				
			} else if (walkStick.GetKey (KeyCode.DownArrow) && walkStick.GetKey (KeyCode.LeftArrow)) {
				return;
			} else if (walkStick.GetKey (KeyCode.DownArrow) && walkStick.GetKey (KeyCode.RightArrow)) {
				return;
			} else if (walkStick.GetKey (KeyCode.UpArrow)) {
				//					if(m_Character.isMovingOnRope)
				//						return;
				//					if(m_Character.isMovingOnLog)
				//						return;
				//					Debug.Log(" Upper");
				PlayerPrefs.SetInt("walkStickStatus",1);
				if(m_Character.swimStatus)
					m_Character.swimUpMovingAnim();
				if (m_Character.swimUpStatus){
					m_Character.swimUpClimbingRightAnim();
				}  
				if (m_Character.JetPackStatus) {
					m_Character.jetPackUpMoving ();
				} else {
					m_Jump = true;
					m_Character.jumpDirectionValue = 0.0f;
					moveTrasfer (h, v);
					
				}
				
			} else if (walkStick.GetKey (KeyCode.DownArrow)) {
				//					if(m_Character.isMovingOnRope)
				//						return;
				//					if(m_Character.isMovingOnLog)
				//						return;
				PlayerPrefs.SetInt("walkStickStatus",1);
				if(PlayerPrefs.GetInt("JetPackStatus") !=1)
				{
					if(m_Character.swimStatus)
						return;
					if (m_Character.JetPackStatus) {
						m_Character.jetPackDownMoving ();
					} else {
						
						if (!SlidingStatus && !m_Character.isSwimStarted &&  !m_Character.clibStartTag) {
							//								SlidingStatus = true;
							//								m_Character.slidingAnimation ();
							//								Invoke ("slidingCompleted", 1.0f);
						}
					}
				}
			} 
			else if (walkStick.GetKey (KeyCode.RightArrow)) {
				PlayerPrefs.SetInt("walkStickStatus",1);
				PlayerPrefs.SetInt("walkStickStatus2",0);
				//					if(m_Character.isMovingOnLog)
				//						m_Character.movingOnLogStatus = true;
				//					if(m_Character.isMovingOnRope)
				//						m_Character.movingOnRopeStatus = true;
				if(m_Character.swimStatus){
					m_Character.swimRightMovingAnim();
				}
				if (m_Character.JetPackStatus)
					return;

				PlayerPrefs.SetInt (ShieldRotateStatus, 1);
				PlayerPrefs.SetInt ("PathRemovalLEFT", 0);

				m_Character.jumpDirectionValue = 0.0f;
				moveTrasfer (h, v);
				return;

			} else if (walkStick.GetKey (KeyCode.LeftArrow)) {
				PlayerPrefs.SetInt("walkStickStatus",1);
				PlayerPrefs.SetInt("walkStickStatus2",1);
				if(m_Character.swimStatus){
					m_Character.swimLeftMovingAnim();
				}
				if (m_Character.JetPackStatus)
					return;
				PlayerPrefs.SetInt (ShieldRotateStatus, 1);
				PlayerPrefs.SetInt ("PathRemovalLEFT", 1);

				m_Character.jumpDirectionValue = 0.0f;
				moveTrasfer (h, v);
				return;
				
			} else if (walkStick.JustReleased ()) {
				PlayerPrefs.SetInt("walkStickStatus",0);
				//					m_Character.movingOnRopeStatus = false;
				//					m_Character.movingOnLogStatus = false;
			} else {
				//				m_Character.movingOnRopeStatus = false;
				//				m_Character.movingOnLogStatus = false;
			}
		}

		if (m_Character.JetPackStatus) {
			h = 0;
		}
		if (h == 0)
			PlayerPrefs.SetInt (ShieldRotateStatus, 0);
		moveTrasfer (h, v);
	
	}
	
	void slidingCompleted()
	{
		SlidingStatus = false;
	}
	
	void moveTrasfer(float h, float v)
	{
		v = 0.0f;
		m_Move = h*Vector3.right;
		m_Character.Move(m_Move, false, m_Jump);
		m_Jump = false;
	}
	
}
//}
