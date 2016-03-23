
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class ThirdPersonCharacter : MonoBehaviour
{
	[SerializeField] float m_MovingTurnSpeed = 360;
	[SerializeField] float m_StationaryTurnSpeed = 180;
	[SerializeField] float m_JumpPower = 12f;
	[SerializeField] float m_GravityMultiplier = 2f;
	[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
	[SerializeField] float m_MoveSpeedMultiplier = 1f;
	[SerializeField] float m_AnimSpeedMultiplier = 1f;
	[SerializeField] float m_GroundCheckDistance = 0.1f;
	public bool hyperJumpStatus = false;
	public bool swimStatus = false;
	public bool swimUpStatus = false;
	
	float m_HyperCapsuleHeight;
	Rigidbody m_Rigidbody;
	Animator m_Animator;
	bool m_IsGrounded;
	float m_OrigGroundCheckDistance;
	const float k_Half = 2.0f;
	float m_TurnAmount;
	float m_ForwardAmount;
	Vector3 m_GroundNormal;
	float m_CapsuleHeight;
	Vector3 m_CapsuleCenter;
	CapsuleCollider m_Capsule;
	bool m_Crouching;
	public float jumpDirectionValue = 0.0f;
	public bool JetPackStatus = false;
	public bool JetPackHeightStatus = false;
	
	
	private float horizontal = 0f;
	private float vertical = 0f;
	private float m_UpDownAmount;
	public bool isSwimStarted = false;
	public bool isVineTouched = false;
	private bool WaterEdge = false;
	
	private int jumpState = 0;
	private int PlayerState = 0;
	private Vector3 newPos;
	private float Reset = 2f;
	private bool clib = false;
	private int turnSide = 0;
	//private float swimFloat;
	
	public GameObject floatWater;
	private GameObject floatWater1;
	public GameObject babble;
	private GameObject babble1;
	ParticleAnimator parvticalSystem;
	bool reduceFloat = true;
	BoxCollider waterTopcldr;
	
	
	public AudioSource audioSource;
	AudioClip audioClips;
	int audioClipIndex = 0;
	AudioSource swimAudioSource;
	AudioClip swimAudioAclip;
	AudioSource footStepSource;
	AudioClip[] footStepClip;
	AudioSource UnderwaterBreatSource;
	AudioClip UnderwaterBreatClip;
	AudioSource FallInWaterAudoSource;
	AudioClip FallInWaterClip;
	AudioClip SwimingrClip;
	AudioSource TopHeadTouchAudoSource;
	AudioClip HealthReductionClip;
	
	private Fish fish;
	private bool movePlayer = false;
	public bool toggleTag = false;
	public bool falldownTag = false;
	public GameObject fallDownCrouchParticals;
	public bool movingOnRopeStatus = false;
	
	
	public bool clibStartTag = false;
	private int hanglevel = 0;
	public Transform hangJoint;
	private Transform tempTranform;
	private Vector3 euler0;
	public bool WaterTag = false;
	private bool movePlayer1 = false;
	
	
	private bool MoveStopTag = false;
	private int hanuThreadPOS = 0;
	
//	string PlatformNameCheck = "";
	public bool BGSoungTag = false;
	private bool StopMovePlayer = false;
	
	
	//	private bool MoveAcceptTag = false;
	public bool DisableTouchStick = false; 
	public bool EnableTouchStick = false; 
	public bool FishTouchTag = false; 
	public bool isWterBottomTouch = false;
	private bool ropehang = false,isColliding = false;

	void changeTarger(){
		if (jumpState == 0) {
			
			if(turnSide == 0)
				newPos = new Vector3 (m_Rigidbody.transform.position.x + 1.4f, m_Rigidbody.transform.position.y + 2.3f, 0);
			if(turnSide == 1) 
				newPos = new Vector3 (m_Rigidbody.transform.position.x - 1.4f, m_Rigidbody.transform.position.y + 2.3f, 0);
			
			jumpState = 1;
			PlayerState = 0;
			Reset = 0.7f;
			Invoke ("changeTarger", Reset);
			WaterEdge = true;
			
		} else if (jumpState == 1) {
			
			Reset = 0.5f;
			jumpState = 2;
			PlayerState = 0;
//			UnderwaterBreatSource.Stop ();
			StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
			Invoke ("changeTarger", Reset);
			WaterEdge = true;
			//Destroy (babble1);
			//Destroy (parvticalSystem);
//			UnderwaterBreatSource.Stop ();
			StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
			
		} else if (jumpState == 2) {
			
			//Destroy (babble1);
			jumpState = 0;
			m_Animator.SetBool ("TouchEdge", false);
			m_Animator.SetBool ("IdleSwim", false);
			
			Reset = 2.0f;
			WaterEdge = false;
			clib = false;
			m_Rigidbody.useGravity = true;
			isSwimStarted = false;
			
			
			m_IsGrounded = true;
			m_Animator.applyRootMotion = true;
			m_Capsule.material.dynamicFriction = 1;
			clib = false;
			
			reduceFloat = true;
			m_Rigidbody.isKinematic = false;
			//			MoveAcceptTag = false;
		}
	}
	
	
	void FixedUpdate()
	{
		isColliding = false;

		if (PlayerPrefs.GetInt ("RotateCameraStatus") == 1) {
			m_Rigidbody.velocity = new Vector3(3,m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
		}
		if (JetPackStatus){
			Physics.gravity =new Vector3(0, 0, 0);
			//				m_Rigidbody.useGravity = false;
//			
//			if(m_Rigidbody.velocity.x<25){
////				if(JetPackHeightStatus)
////					m_Rigidbody.AddForce(new Vector3(0.0001f, 0.01f,0.0f),ForceMode.Acceleration);
////				else
//					m_Rigidbody.AddForce(new Vector3(0.0001f, 1.01f,0.0f),ForceMode.Acceleration);
//			}
//			else
				m_Rigidbody.velocity = new Vector3(25,m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
		}
	}

	IEnumerator LoadAudioFiles_Hanuman(){
		yield return new WaitForSeconds (1f);

		//PLay App BackGround sounds.....
		audioSource = (AudioSource)gameObject.AddComponent<AudioSource>();
//		audioClips = Resources.LoadAll<AudioClip>("Sounds");
//		audioSource.volume = 1f;
//		audioSource.pitch = 0.5f;
		audioClips = (AudioClip)Resources.Load ("Sounds2/Timpani Hanuman Theme1");

		audioSource.clip = audioClips;
		audioSource.volume = 1f;
		audioSource.pitch = 1f;
		audioSource.Play ();
		audioSource.loop = true;
		//StartCoroutine (NextSoundClip ());



		swimAudioSource = (AudioSource)gameObject.AddComponent<AudioSource>();
		swimAudioAclip = (AudioClip)Resources.Load ("SingleSounds/Hanuman Islanf Theme");
		swimAudioSource.volume = 0.5f;
		FallInWaterAudoSource = (AudioSource)gameObject.AddComponent<AudioSource>();
		FallInWaterClip = (AudioClip)Resources.Load ("SingleSounds/Falling in Water");
		SwimingrClip = (AudioClip)Resources.Load ("SingleSounds/Swiming");
		UnderwaterBreatSource = (AudioSource)gameObject.AddComponent<AudioSource>();
		UnderwaterBreatClip = (AudioClip)Resources.Load ("SingleSounds/Underwater Breathing");
		UnderwaterBreatSource.clip = UnderwaterBreatClip;
		UnderwaterBreatSource.loop = true;
		TopHeadTouchAudoSource = (AudioSource)gameObject.AddComponent<AudioSource>();
		HealthReductionClip = (AudioClip)Resources.Load ("SingleSounds/Health Reduction");
		TopHeadTouchAudoSource.clip = HealthReductionClip;
//		footStepSource = (AudioSource)gameObject.AddComponent<AudioSource>();
//		footStepClip = Resources.LoadAll<AudioClip>("FootSounds");
		//playsoud ();

	}
	
	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Capsule = GetComponent<CapsuleCollider>();
		m_CapsuleHeight = m_Capsule.height;
		m_CapsuleCenter = m_Capsule.center;
		m_HyperCapsuleHeight = m_Capsule.height+0.03f;
		euler0 = m_Rigidbody.transform.eulerAngles;
		
		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
		m_OrigGroundCheckDistance = m_GroundCheckDistance;
		
		StartCoroutine (LoadAudioFiles_Hanuman());

		

	}
	void PlayFootStepSound(){
		try{
//		footStepSource.clip = footStepClip [Random.Range (0, footStepClip.Length)];
//		footStepSource.volume = 0.8f;
//		footStepSource.pitch = 0.6f;
//		footStepSource.Play ();
		}catch{

		}
	}
//	void playsoud(){
//		
//		//if (!BGSoungTag) {
//			
//			audioSource.clip = audioClips [audioClipIndex];
//			audioSource.volume = 1f;
//			audioSource.pitch = 1f;
//			audioSource.Play ();
//			StartCoroutine (NextSoundClip ());
//		//}
//	}
//	
//	IEnumerator NextSoundClip() {
//		yield return new WaitForSeconds (audioSource.clip.length);
////			(audioSource.clip.length);
//		if (audioClips.Length == audioClipIndex+1)
//			audioClipIndex = 0;
//		else
//			audioClipIndex++;
//		if(!isSwimStarted)
//			playsoud ();
//	}


//	IEnumerator ChangeColiderValues() {
//		yield return new WaitForSeconds(0.5f);
//
//		m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
//		m_Capsule.height = 0.1f;
//		m_Capsule.radius = 0.07f;
//
//	}
	public void Move(Vector3 move, bool crouch, bool jump)
	{
		
		m_UpDownAmount = CFInput.GetAxis("Vertical");
		horizontal = CFInput.GetAxis("Horizontal");

		if(ropehang){
			if(horizontal >= 0)
			m_Rigidbody.transform.position = Vector3.MoveTowards (m_Rigidbody.transform.position, newPos, horizontal* Time.deltaTime*10.0f);
		}
		if (isSwimStarted) {
			
			if (WaterEdge) {
				if (!clib) {
					clib = true;
					changeTarger ();
					try{
						fish.fishTag = false;
					}
					catch{
					}
//					UnderwaterBreatSource.Stop ();
					StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
					Destroy (babble1);
				}
				
				m_Rigidbody.transform.position = Vector3.Lerp (m_Rigidbody.transform.position, newPos, 2.2f * Time.deltaTime); 
				m_Animator.SetBool ("TouchEdge", true);
			} else {
				
				if (move.magnitude > 1f)
					move.Normalize ();
				move = transform.InverseTransformDirection (move);
				
				move = Vector3.ProjectOnPlane (move, m_GroundNormal);
				m_TurnAmount = Mathf.Atan2 (move.x, move.z);
				m_ForwardAmount = move.z;
				ApplyExtraTurnRotation ();
				
				
				if (horizontal > 0) {
					turnSide = 0;
				}
				if (horizontal < 0) {
					turnSide = 1;
				}
				
				if(movePlayer){
					
					m_Rigidbody.transform.Translate (0f, 5f * m_UpDownAmount * Time.deltaTime, 0);
					// update the animator parameters
					m_Animator.SetFloat ("Forward", m_ForwardAmount);
					movePlayer1 = false;
				}
				else{
					if(m_UpDownAmount<0){
						movePlayer = true;
						movePlayer1 = true;     
						m_UpDownAmount = Input.GetAxis("Vertical");
						m_Rigidbody.transform.Translate (0f, 5f * m_UpDownAmount * Time.deltaTime, 0);
					}
					m_Animator.SetFloat ("Forward", m_ForwardAmount);
				}
				
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				m_Capsule.material.dynamicFriction = 1;
				
				
				if(!FishTouchTag){
					m_Rigidbody.isKinematic = false;
				}
				
				try{
					if(turnSide == 0)
						babble1.transform.position = new Vector3(this.transform.position.x+1f,this.transform.position.y+0.5f,this.transform.position.z);
					else
						babble1.transform.position = new Vector3(this.transform.position.x-1f,this.transform.position.y+0.5f,this.transform.position.z);
				}
				catch{
				}
			}
			
		} 
		else if(clibStartTag){
			
			
			if(hanuThreadPOS == 2){
				try{
					if(turnSide == 0)
						babble1.transform.position = new Vector3(this.transform.position.x+1f,this.transform.position.y+0.5f,this.transform.position.z);
					else
						babble1.transform.position = new Vector3(this.transform.position.x-1f,this.transform.position.y+0.5f,this.transform.position.z);				
				}
				catch{
				}
			}
			
			if(horizontal>0){
				if(StopMovePlayer){
					return;
				}
			}
			else if(horizontal<0){
				if(StopMovePlayer){
					return;
				}
			}
			else{
				StopMovePlayer = false;
			}
			
			
			if(hanglevel == 1){
				
				if(!MoveStopTag){
					
//					if(m_UpDownAmount > 0.15 && horizontal > 0.95){
//						return;
//					}
//					
//					if(m_UpDownAmount < -0.95 && horizontal < -0.95){
//						return;
//					}
//					
//					if(m_UpDownAmount > 0.5 || m_UpDownAmount < -0.5){
//						
//						m_Rigidbody.transform.Translate (0f, 2f * m_UpDownAmount * Time.deltaTime, 0);
//						m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
//						m_Animator.SetBool("jumpUpVineTag",true);
//						
//						m_Animator.applyRootMotion = true;
//					}
//					else{
//						
//						if(m_UpDownAmount== 0)
//							m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
//						m_Animator.SetBool("jumpUpVineTag",false);
//					}



					if(m_UpDownAmount > 0.5 || m_UpDownAmount < -0.5){
						
//						m_Animator.SetBool("jumpUpVineTag",true);
						m_Rigidbody.transform.Translate (0f, 2f * m_UpDownAmount * Time.deltaTime, 0);
						m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
						m_Animator.SetFloat ("JumpfromVine",2f * horizontal);
						m_Animator.applyRootMotion = true;
					}
					else{
						m_Animator.SetFloat ("jumpUpVine",0);
						m_Animator.SetFloat ("JumpfromVine",0);
					}

				}
				else{
					m_UpDownAmount = CFInput.GetAxis("Vertical");
					if(m_UpDownAmount < 0){
						
						MoveStopTag = false;
						
						m_Rigidbody.transform.Translate (0f, 2f * m_UpDownAmount * Time.deltaTime, 0);
						m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
//						m_Animator.SetBool("jumpUpVineTag",true);
						//m_IsGrounded = true;
						m_Animator.applyRootMotion = true;
					}
					else{
						m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
//						m_Animator.SetBool("jumpUpVineTag",false);
					}
				}
			}
			else if(hanglevel == 2){


				m_Animator.SetFloat ("jumpUpVine",0);
				m_Animator.SetFloat ("JumpfromVine",0);

				//				m_Animator.SetFloat ("jumpUpVine",0);
				//				//m_Rigidbody.transform.rotation = hangJoint.transform.rotation;
				//				m_Rigidbody.transform.eulerAngles = euler0;
				//				m_Rigidbody.transform.position = hangJoint.transform.position;
				//				m_Rigidbody.transform.position = new Vector3(m_Rigidbody.transform.position.x,m_Rigidbody.transform.position.y-1.2f,m_Rigidbody.transform.position.z);
				//				
				//				//m_Animator.SetFloat ("jumpUpVine",2f * m_UpDownAmount);
				//				//m_IsGrounded = true;
				//				//m_Animator.applyRootMotion = true;
			}
			else if(hanglevel == 3){ 
				
				m_Rigidbody.isKinematic = false;
				
				if (move.magnitude > 1f)
					move.Normalize ();
				move = transform.InverseTransformDirection (move);
				
				move = Vector3.ProjectOnPlane (move, m_GroundNormal);
				m_TurnAmount = Mathf.Atan2 (move.x, move.z);
				m_ForwardAmount = move.z;
				ApplyExtraTurnRotation ();
				
				
				m_Rigidbody.transform.Translate (0f, 0f, horizontal * Time.deltaTime);
				//m_Animator.SetFloat ("Forward", m_ForwardAmount);
				m_Animator.SetFloat ("ClibMove",horizontal);
				
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				m_Capsule.material.dynamicFriction = 1;
				
				return;
			}
			
			if(horizontal >= 0.5){
				
				m_Animator.SetFloat ("jumpUpVine",0.0f);
//				m_Animator.SetBool("jumpUpVineTag",false);
				
				
				if(hanuThreadPOS == 2){
					
					newPos = new Vector3 (m_Rigidbody.transform.position.x + 9.0f, m_Rigidbody.transform.position.y + 0f, 0);
					m_Rigidbody.transform.position = Vector3.Slerp (m_Rigidbody.transform.position, newPos, 9.0f * Time.deltaTime);
					
					m_Rigidbody.isKinematic = false;
					clibStartTag = false;
					
					hanglevel = 0;
					isSwimStarted = true;
					clibStartTag = false;
					movePlayer = true;
					
					m_Animator.SetBool ("IdleSwim", true);
					m_Animator.SetBool ("OnGround", false);
					m_Animator.SetBool ("HangVine", false);
					m_Animator.SetFloat ("jumpUpVine",0);
//					m_Animator.SetBool("jumpUpVineTag",false);
					
					m_Rigidbody.isKinematic = false;
					
					
					m_IsGrounded = true;
					m_Animator.applyRootMotion = true;
					m_Capsule.material.dynamicFriction = 1;
					
					
					m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
					m_Capsule.height = 0.1f;
					m_Capsule.radius = 0.07f;
					
				}
				else{
					
					DisableTouchStick = true;
					m_Rigidbody.isKinematic = false;
					
					if(hanglevel == 2){
						newPos = new Vector3 (m_Rigidbody.transform.position.x + 20.0f, m_Rigidbody.transform.position.y + 0f, 0);
						this.transform.parent = null;
						m_Rigidbody.transform.position = Vector3.Lerp (m_Rigidbody.transform.position, newPos, 13f * Time.deltaTime);
					}
					else{
						newPos = new Vector3 (m_Rigidbody.transform.position.x + 20.0f, m_Rigidbody.transform.position.y + 0f, 0);
						m_Rigidbody.transform.position = Vector3.Slerp (m_Rigidbody.transform.position, newPos, 4.5f * Time.deltaTime);
					}
					
					m_IsGrounded = true;
					//isSwimStarted = false;
					m_Rigidbody.useGravity = true;

					
					clibStartTag = false;
					m_Animator.SetBool ("OnGround", true);
					m_Animator.SetBool ("HangVine", false);
					hanglevel = 0;
					
					m_Rigidbody.transform.eulerAngles = euler0;
					hanuThreadPOS = 0;
					
				}
			}
			
			if(horizontal <= -0.5){
				
				m_Animator.SetFloat ("jumpUpVine",0.0f);
//				m_Animator.SetBool("jumpUpVineTag",false);
				
				if(hanuThreadPOS == 2){
					
					newPos = new Vector3 (m_Rigidbody.transform.position.x - 9.0f, m_Rigidbody.transform.position.y + 0f, 0);
					m_Rigidbody.transform.position = Vector3.Slerp (m_Rigidbody.transform.position, newPos, 9f * Time.deltaTime);
					
					
					m_Rigidbody.isKinematic = false;

					hanglevel = 0;
					isSwimStarted = true;
					clibStartTag = false;
					movePlayer = true;
					
					m_Animator.SetBool ("IdleSwim", true);
					m_Animator.SetBool ("OnGround", false);
					m_Animator.SetBool ("HangVine", false);
					m_Animator.SetFloat ("jumpUpVine",0);
//					m_Animator.SetBool("jumpUpVineTag",false);
					
					m_Rigidbody.isKinematic = false;
					
					
					m_IsGrounded = true;
					m_Animator.applyRootMotion = true;
					m_Capsule.material.dynamicFriction = 1;
					
					
					m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
					m_Capsule.height = 0.1f;
					m_Capsule.radius = 0.07f;
					
				}
				else{
					
					DisableTouchStick = true;
					m_Rigidbody.isKinematic = false;
					
					if(hanglevel == 2){
						newPos = new Vector3 (m_Rigidbody.transform.position.x - 20.0f, m_Rigidbody.transform.position.y + 0f, 0);
						this.transform.parent = null;
						m_Rigidbody.transform.position = Vector3.Lerp (m_Rigidbody.transform.position, newPos, 13f * Time.deltaTime);
					}
					else{
						newPos = new Vector3 (m_Rigidbody.transform.position.x - 20.0f, m_Rigidbody.transform.position.y + 0f, 0);
						m_Rigidbody.transform.position = Vector3.Slerp (m_Rigidbody.transform.position, newPos, 4.5f * Time.deltaTime);
					}
					
					
					m_IsGrounded = true;
					//isSwimStarted = false;
					m_Rigidbody.useGravity = true;
					clibStartTag = false;
					
					
					m_Animator.SetBool ("OnGround", true);
					m_Animator.SetBool ("HangVine", false);
					hanglevel = 0;
					m_Rigidbody.transform.eulerAngles = euler0;
					hanuThreadPOS = 0;
				}
				
			}
		}
		else {
			
			//			if(MoveAcceptTag)
			//				return;
			
			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			
			if (horizontal > 0) {
				turnSide = 0;
			}
			if (horizontal < 0) {
				turnSide = 1;
			}
			
			
			if (movingOnRopeStatus) {
				m_Animator.SetFloat("RopeWalk",horizontal);
			}
			
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			if (!JetPackStatus)
				CheckGroundStatus ();
			else {
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				m_Capsule.material.dynamicFriction = 1;
			}
			CheckGroundStatus();
			move = Vector3.ProjectOnPlane(move, m_GroundNormal);
			m_TurnAmount = Mathf.Atan2(move.x, move.z);
			m_ForwardAmount = move.z;
			ApplyExtraTurnRotation();
			
			// control and velocity handling is different when grounded and airborne:
			if (m_IsGrounded){
				HandleGroundedMovement(crouch, jump);
			}
			else{
				HandleAirborneMovement();
			}
			
			ScaleCapsuleForCrouching(crouch);
			PreventStandingInLowHeadroom();
			
			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}
		try{
			fish.wayPoint = this.transform;
		}
		catch{
		}
	}
	
	
	void ScaleCapsuleForCrouching(bool crouch)
	{
		if (m_IsGrounded && crouch)
		{
			if (m_Crouching) return;
			m_Capsule.height = m_Capsule.height / 2f;
			m_Capsule.center = m_Capsule.center / 2f;
			m_Crouching = true;
		}
		else
		{
			Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
			float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
			if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength))
			{
				m_Crouching = true;
				return;
			}
			m_Capsule.height = m_CapsuleHeight;
			m_Capsule.center = m_CapsuleCenter;
			if(hyperJumpStatus)
				m_Capsule.height = m_HyperCapsuleHeight;
			//				m_Crouching = false;
			
		}
	}
	
	void PreventStandingInLowHeadroom()
	{
		// prevent standing up in crouch-only zones
		if (!m_Crouching)
		{
			Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
			float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
			if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength))
			{
				m_Crouching = true;
			}
		}
	}
	
	void UpdateAnimator(Vector3 move)
	{
		if (PlayerPrefs.GetInt ("RotateCameraStatus") == 1) {
			m_Animator.SetFloat ("Forward", 1);
		}
		
		if (JetPackStatus) {
			m_Animator.SetBool ("JetPack", true);
			
		}
		
		else {
			m_Animator.SetBool ("JetPack", false);
			m_Animator.SetFloat ("IdelType", 0);
			m_Animator.SetFloat ("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
			
			if (hyperJumpStatus)
				m_Animator.SetFloat ("RunType", 1f);
			else
				m_Animator.SetFloat ("RunType", 0f);
			
			m_Animator.SetFloat ("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
			m_Animator.SetBool ("OnGround", m_IsGrounded);
			int GroundTouchTypeValue = PlayerPrefs.GetInt ("GroundTouchType");
			if (GroundTouchTypeValue == 1 && m_IsGrounded) {
				m_Crouching = true;
				PlayerPrefs.SetInt ("GroundTouchType", 0);
				m_Animator.SetFloat ("GroundHitType", 0f);
				Invoke ("CompletePlatfromJump", 0.5f);
			}
			m_Animator.SetBool ("Crouch", false);
			
			if (!m_IsGrounded) {
				m_Animator.SetFloat ("Jump", m_Rigidbody.velocity.y);
				//m_Animator.SetFloat ("Fall", m_Rigidbody.velocity.y);
			}
			
			
			if(falldownTag){
				
				if(!m_Animator.GetBool("Fall")){
					m_Animator.SetBool ("Falll", true);
				}
				
				if(m_IsGrounded){
					GameObject ps_Gobj = (GameObject)Instantiate (fallDownCrouchParticals, transform.position, Quaternion.identity);
					StartCoroutine (destroyPS (ps_Gobj));
					
					m_Animator.SetBool ("Falll",false);
					falldownTag = false;
//					TopHeadTouchAudoSource.Play ();
					StartCoroutine(TopHeadTouchAudoSourceSound(TopHeadTouchAudoSource));
				}
			}
			
			
			float runCycle =Mathf.Repeat(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
			if (m_IsGrounded)
			{
				m_Animator.SetFloat("JumpLeg", jumpLeg);
			}
			if (m_IsGrounded && move.magnitude > 0)
			{
				m_Animator.speed = m_AnimSpeedMultiplier;
			}
			else
			{
				m_Animator.speed = 1;
			}
		}
	}
	
	
	IEnumerator destroyPS (GameObject gameObject)
	{
		yield return new WaitForSeconds (1f);
		//ps.GetComponent<ParticleSystem> ().Stop ();
		GameObject.Destroy (gameObject);
	}
	
	//		void HandleAirborneMovement()
	//		{
	//			// apply extra gravity from multiplier:
	//			Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
	//			m_Rigidbody.AddForce(extraGravityForce);
	//
	//			m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
	//		}
	
	void HandleAirborneMovement()
	{
		
		// apply extra gravity from multiplier:
		//m_Rigidbody.velocity = new Vector3(jumpDirectionValue, m_Rigidbody.velocity.y, 0);
		//			Debug.Log ("jumpDirectionValue is:"+jumpDirectionValue);
		Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
		extraGravityForce.x = jumpDirectionValue;
		if (hyperJumpStatus) {
			
			extraGravityForce.y = 0.4f;
		}
		m_Rigidbody.AddForce(extraGravityForce);
		
		m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.4f;
	}
	
	
	void HandleGroundedMovement(bool crouch, bool jump)
	{
		// check whether conditions are right to allow a jump:
		if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo (0).IsName ("Grounded")) {
			// jump!
			
			m_Rigidbody.velocity = new Vector3 (0, m_JumpPower, m_Rigidbody.velocity.z);
			m_IsGrounded = false;
			m_Animator.applyRootMotion = false;
			m_GroundCheckDistance = 0.1f;
		} else {
			if (hyperJumpStatus) {
				Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
				extraGravityForce.y = 10f;
				//        extraGravityForce.x = 30f;
				//					Debug.Log ("debug log :" + m_Rigidbody.velocity.y);
				m_Rigidbody.AddForce (extraGravityForce);
			}
		}
	}
	
	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}
	
	
	public void OnAnimatorMove()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (m_IsGrounded && Time.deltaTime > 0)
		{
			Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;
			
			// we preserve the existing y part of the current velocity.
			v.y = m_Rigidbody.velocity.y;
			m_Rigidbody.velocity = v;
		}
	}
	
	
	void CheckGroundStatus()
	{

		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		//			Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
		#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
		{

			m_GroundNormal = hitInfo.normal;
			m_IsGrounded = true;
			m_Animator.applyRootMotion = true;
			m_Capsule.material.dynamicFriction=1;
		}
		else
		{

			m_IsGrounded = false;
			m_GroundNormal = Vector3.up;
			m_Animator.applyRootMotion = false;
			m_Capsule.material.dynamicFriction=0;
		}
	}
	
	public void playerVelocityZero(){
		m_Rigidbody.velocity = Vector3.zero;
		
		
	}
	public void slidingAnimation()
	{
		m_Animator.SetTrigger("Sliding");
	}
	public void jetPackUpMoving()
	{
		m_Rigidbody.AddForce(new Vector3(0.1f, 120.51f,0.0f),ForceMode.Acceleration);
	}
	public void jetPackDownMoving()
	{
		m_Rigidbody.AddForce(new Vector3(0.1f, -120.51f,0.0f),ForceMode.Acceleration);
	}
	
	public void swimRightMovingAnim()
	{
		m_Rigidbody.AddForce (new Vector3(80,0,0));
	}
	public void swimUpMovingAnim()
	{
		m_Rigidbody.AddForce (new Vector3(0,50,0));
	}
	public void swimLeftMovingAnim()
	{
		m_Rigidbody.AddForce (new Vector3(-80,0,0));
	}
	public void swimUpClimbingRightAnim()
	{
		m_Rigidbody.AddForce (new Vector3(4,4,0));
	}
	public void swimUpClimbingLeftAnim()
	{
		m_Rigidbody.AddForce (new Vector3(-4,-4,0));
	}


	IEnumerator PlayWaterSound (AudioSource a,AudioClip c)
	{
		yield return new WaitForSeconds (0.1f);
		a.clip = c;
		a.loop = true;
		a.Play ();
	}
	IEnumerator TopHeadTouchAudoSourceSound(AudioSource a){
		yield return new WaitForSeconds (0.1f);
		a.Play ();
	}

	IEnumerator UnderwaterBreatSourceSound(AudioSource a){

		yield return new WaitForSeconds (0.1f);
		a.Play ();
	}

	IEnumerator UnderwaterBreatSourceSound_STOP(AudioSource a){
		
		yield return new WaitForSeconds (0.1f);
		a.Stop ();
	}

	IEnumerator PlayWaterSound_STOP (AudioSource a)
	{
		yield return new WaitForSeconds (0.1f);
		a.Stop ();
	}

	IEnumerator FishTouchTagDisable() {
		yield return new WaitForSeconds(0.5f);
		FishTouchTag = false;
		m_Rigidbody.isKinematic = false;
	}
	IEnumerator EnableJoyStick() {

		yield return new WaitForSeconds(0.5f);
		EnableTouchStick = true;
		DisableTouchStick = false;
	}



	void OnCollisionExit(Collision collision) {
		
		if (collision.collider.gameObject.name.Equals ("Cylinder")) {
			movingOnRopeStatus = false; 
			m_Animator.SetFloat ("RopeWalk", 0);
			m_Animator.SetBool ("IsIdealOnRope", false);
		}
		else if (collision.collider.gameObject.tag == "WaterBottom") {
			
			isWterBottomTouch = false;
			//			m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
			//			m_Capsule.height = 0.1f;
			//			m_Capsule.radius = 0.07f;
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if (DisableTouchStick) {
			EnableTouchStick = true;
			DisableTouchStick = false;
		}
		
		if (collision.collider.gameObject.name.Equals ("Cylinder")) {
			
			if(!movingOnRopeStatus){
				movingOnRopeStatus = true;
				m_Animator.SetBool("IsIdealOnRope",true);
				
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				m_Capsule.material.dynamicFriction = 1;
			}
		}
		else if (collision.collider.gameObject.tag == "WaterBottom") {


			if(isWterBottomTouch)
				return;

			DisableTouchStick = true;
			isWterBottomTouch = true;
			newPos = new Vector3 (m_Rigidbody.transform.position.x, m_Rigidbody.transform.position.y + 12.0f, m_Rigidbody.transform.position.z);
			m_Rigidbody.transform.position = Vector3.Slerp (m_Rigidbody.transform.position, newPos, 2.0f * Time.deltaTime);


			audioSource.Pause ();

			if(!swimAudioSource.isPlaying)
				StartCoroutine(PlayWaterSound(swimAudioSource,swimAudioAclip));
//			;
//			swimAudioSource.clip = swimAudioAclip;
//			swimAudioSource.loop = true;
//			swimAudioSource.Play ();
			
			
			isSwimStarted = true;
			m_Rigidbody.useGravity = false;
			
			//Play IdleSwim....
			m_Animator.SetBool ("IdleSwim", true);
			m_Animator.SetBool ("OnGround", false);

			GameObject go;
			try{
				go = (GameObject)collision.collider.gameObject.transform.parent.parent.parent.parent.gameObject;
				fish = go.transform.FindChild("fish").GetComponent<Fish> ();
				fish.fishTag = true;
			}
			catch{

				go = (GameObject)collision.collider.gameObject.transform.parent.parent.gameObject;
				fish = go.transform.FindChild("fish").GetComponent<Fish> ();
				fish.fishTag = true;
			}

			//			MoveAcceptTag = false;
			PlayerState = 1;
			StartCoroutine (EnableJoyStick ());
			
		} else if (collision.collider.gameObject.tag == "WaterEdge") {
			
//			if (isSwimStarted) {
//				
//				swimAudioSource.Stop ();
//				StartCoroutine(PlayWaterSound_STOP(swimAudioSource));
//				audioSource.Play ();
//				//playsoud ();
//				UnderwaterBreatSource.Stop ();
//				StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
//
//				Destroy (waterTopcldr);
//				try{
//					fish.fishTag = false;
//				}
//				catch{
//				}
//				m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
//				m_Capsule.height = 0.16f;
//				m_Capsule.radius = 0.035f;
//				m_Rigidbody.isKinematic = true;
//				WaterEdge = true;
//				//				MoveAcceptTag = false;
//				PlayerState = 0;
//			}

			if (isSwimStarted) {
				if(turnSide == 1){
					if(this.transform.eulerAngles.y > 260 || this.transform.eulerAngles.y < 280){
						if(this.transform.position.x > collision.collider.transform.position.x){
							swimAudioSource.Stop ();
							StartCoroutine(PlayWaterSound_STOP(swimAudioSource));
							audioSource.Play ();
							//playsoud ();
							UnderwaterBreatSource.Stop ();
							StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
							Destroy (waterTopcldr);
							try{
								fish.fishTag = false;
							}
							catch{

							}
							m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
							m_Capsule.height = 0.16f;
							m_Capsule.radius = 0.035f;
							m_Rigidbody.isKinematic = true;
							WaterEdge = true;
							PlayerState = 0;
						}
					}
				}
				else{
					if(this.transform.eulerAngles.y > 80 || this.transform.eulerAngles.y < 100){
						if(this.transform.position.x < collision.collider.transform.position.x){
							swimAudioSource.Stop ();
							StartCoroutine(PlayWaterSound_STOP(swimAudioSource));
							audioSource.Play ();
							UnderwaterBreatSource.Stop ();
							StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
							Destroy (waterTopcldr);
							try{
								fish.fishTag = false;
							}
							catch{

							}
							m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
							m_Capsule.height = 0.16f;
							m_Capsule.radius = 0.035f;
							m_Rigidbody.isKinematic = true;
							WaterEdge = true;
							PlayerState = 0;
						}
					}
				}
			}
		} 
		else if (collision.collider.gameObject.name.Equals ("1_vine")) {
			
			isVineTouched = false;
			if(turnSide == 0){
				m_Rigidbody.transform.eulerAngles = euler0;
				transform.position = new Vector3(collision.collider.transform.position.x-0.2f,collision.collider.transform.position.y,collision.collider.transform.position.z);
			}
			else{
				m_Rigidbody.transform.eulerAngles = -euler0;
				transform.position = new Vector3(collision.collider.transform.position.x+0.2f,collision.collider.transform.position.y,collision.collider.transform.position.z);
			}
			
			hanuThreadPOS = 1;
			hanglevel = 1;
			clibStartTag = true;
			isSwimStarted = false;
			
			
			m_Rigidbody.isKinematic = true;
			m_IsGrounded = false;
			m_Rigidbody.useGravity = false;
			m_Animator.SetBool ("HangVine", true);
			
			m_Rigidbody.detectCollisions = true;
			m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			
			m_Animator.SetBool ("OnGround", false);
			m_Animator.SetBool ("TouchEdge", false);
			m_Animator.SetBool ("IdleSwim", false);
			
		} 
		else if (collision.collider.gameObject.name.Equals ("1_vine2")) {
			
			if(FishTouchTag){
				m_Rigidbody.isKinematic = true;
				return;
			}
			
			isVineTouched = true;
			if(turnSide == 0){
				m_Rigidbody.transform.eulerAngles = euler0;
				transform.position = new Vector3(collision.collider.transform.position.x-0.2f,collision.collider.transform.position.y,collision.collider.transform.position.z);
			}
			else{
				m_Rigidbody.transform.eulerAngles = -euler0;
				transform.position = new Vector3(collision.collider.transform.position.x+0.2f,collision.collider.transform.position.y,collision.collider.transform.position.z);
			}
			
			StopMovePlayer = true;
			hanuThreadPOS = 2;
			hanglevel = 1;
			clibStartTag = true;
			isSwimStarted = false;
			
			
			m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
			m_Capsule.height = 0.16f;
			m_Capsule.radius = 0.035f;
			
			m_Rigidbody.isKinematic = true;
			m_IsGrounded = false;
			m_Rigidbody.useGravity = false;
			m_Rigidbody.detectCollisions = true;
			m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			m_Animator.SetBool ("HangVine", true);
			
			
			jumpState = 0;
			
			m_Animator.SetBool ("TouchEdge", false);
			m_Animator.SetBool ("IdleSwim", false);
			m_Animator.SetBool ("OnGround", false);
			
			audioSource.Pause();
			
		} 
		else if (collision.collider.gameObject.name.Equals ("joint59")) {
			hanglevel = 2;
			//m_Rigidbody.transform.eulerAngles = euler0;
			clibStartTag = true;
			isSwimStarted = false;
			
			if(turnSide == 0){
				
				this.transform.position = collision.collider.gameObject.transform.position;
				this.transform.eulerAngles  = new Vector3(collision.collider.gameObject.transform.eulerAngles.x,euler0.y,euler0.z);
				this.transform.parent = collision.collider.gameObject.transform;
			}
			else{
				
				this.transform.position = collision.collider.gameObject.transform.position;
				this.transform.eulerAngles  = new Vector3(-collision.collider.gameObject.transform.eulerAngles.x,-euler0.y,euler0.z);
				this.transform.parent = collision.collider.gameObject.transform;
			}
			
			//tempTranform.transform.parent = (Transform)this.transform;
			hangJoint = (Transform)collision.collider.transform;
			m_Animator.SetBool ("HangVine", true);
			m_IsGrounded = false;
			m_Rigidbody.useGravity = false;
			m_Rigidbody.isKinematic = true;
			
			if(turnSide == 0){
				transform.position = new Vector3(transform.position.x-0.2f,transform.position.y,transform.position.z);
			}
			else{
				transform.position = new Vector3(transform.position.x+0.2f,transform.position.y,transform.position.z);
			}
			
			
		} else if (collision.collider.gameObject.name.Equals ("upper")) {
			
			hanglevel = 3;
			clibStartTag = true;
			isSwimStarted = false;
			
			m_IsGrounded = false;
			m_Rigidbody.useGravity = false;
			m_Rigidbody.isKinematic = true;
			m_Animator.SetBool ("HangVine1", true);
			
		} else if (collision.collider.gameObject.name.Equals ("upperend")) {
			
			clibStartTag = false;
			m_IsGrounded = true;
			m_Animator.SetBool ("OnGround", m_IsGrounded);
			m_Rigidbody.useGravity = true;
			//m_Animator.SetBool ("HangVine", false);
			m_Animator.SetBool ("HangVine1", false);
			hanglevel = 0;
			m_Animator.SetFloat ("ClibMove", 0.0f);
		}
		else if (collision.collider.gameObject.name.Equals ("Cylinder0 (3)") ||
		         collision.collider.gameObject.name.Equals ("Cylinder0 (2)")) {
			try{
				if(isColliding) return;
				isColliding = true;
				m_Rigidbody.transform.position = collision.collider.gameObject.transform.parent.parent.GetChild(1).position;
				m_Rigidbody.transform.eulerAngles = euler0;
				m_Animator.SetBool ("ropeslide", true);
				m_Animator.applyRootMotion = true;
				newPos = collision.collider.gameObject.transform.parent.parent.GetChild(2).position;
				collision.collider.gameObject.transform.parent.parent = this.transform;
				m_IsGrounded = false;
				m_Rigidbody.useGravity = false;
				m_Rigidbody.isKinematic = true;
				StartCoroutine(hanganimdelayoffset());
			}
			catch{}
		}

	}
	IEnumerator hanganimdelayoffset(){
		yield return new WaitForSeconds(1f);
		ropehang = true;
	}

	void OnTriggerEnter(Collider collider) {
		
		if (collider.gameObject.tag == "fish") {
			
			if(!isSwimStarted && !isVineTouched)
				return;
			
			//FishTouchTag = true;
			//m_Rigidbody.isKinematic = true;
			
			if(clibStartTag){
				
//				m_Animator.SetBool ("HangVine", false);
//				m_Animator.SetBool ("IdleSwim", true);
//				m_Animator.SetBool ("OnGround", false);
//				
//				m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
//				m_Capsule.height = 0.1f;
//				m_Capsule.radius = 0.07f;


				m_Rigidbody.isKinematic = false;
				clibStartTag = false;
				
				hanglevel = 0;
				isSwimStarted = true;
				clibStartTag = false;
				movePlayer = true;
				
				m_Animator.SetBool ("IdleSwim", true);
				m_Animator.SetBool ("OnGround", false);
				m_Animator.SetBool ("HangVine", false);
				m_Animator.SetFloat ("jumpUpVine",0);
//				m_Animator.SetBool("jumpUpVineTag",false);
				
				m_Rigidbody.isKinematic = false;
				
				
				m_IsGrounded = true;
				m_Animator.applyRootMotion = true;
				m_Capsule.material.dynamicFriction = 1;
				
				
				m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
				m_Capsule.height = 0.1f;
				m_Capsule.radius = 0.07f;
				
			}
			else{
				FishTouchTag = true;
				StartCoroutine (FishTouchTagDisable());
			}
		}else if (collider.gameObject.tag == "WaterSide") {

			try{
			GameObject go = (GameObject)collider.gameObject.transform.parent.parent.parent.gameObject;
			fish = go.transform.FindChild("fish").GetComponent<Fish> ();
			fish.fishTag = true;
			}catch{

			}
		}
		
		else if (collider.gameObject.name == "EndVine1") {
			
			if(collider.transform.position.y > transform.position.y){
				
				isVineTouched = false;
				hanuThreadPOS = 1;

				try{
					fish.fishTag = false;
				}
				catch{
				}

				//if (babble1) {
				Destroy (babble1);
				Destroy (parvticalSystem);
//				UnderwaterBreatSource.Stop ();
				StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
				
				BGSoungTag = false;
//				swimAudioSource.Stop ();
				StartCoroutine(PlayWaterSound_STOP(swimAudioSource));
				audioSource.Play ();
//				playsoud ();
//				UnderwaterBreatSource.Stop ();
				StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
				
				Destroy (waterTopcldr);
				try{
					fish.fishTag = false;
				}
				catch{
				}
				m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
				m_Capsule.height = 0.16f;
				m_Capsule.radius = 0.035f;
				m_Rigidbody.isKinematic = true;
				//}
			}
			
		}
		else if (collider.gameObject.tag == "WaterTop") {
			try{
			collider.transform.parent.GetChild(0).GetComponent<RealisticWater>().enabled = true;
			collider.transform.GetComponent<RealisticWater>().enabled = true;
			collider.transform.GetComponent<TI_Waves>().enabled = true;
			
			}catch{

			}
			if(clibStartTag){
			}
			else{
				
				if (babble1) {
					Destroy (babble1);
					Destroy (parvticalSystem);
//					UnderwaterBreatSource.Stop ();
					StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
				}
				babble1 = Instantiate (babble) as GameObject;
				parvticalSystem = babble1.GetComponent<ParticleAnimator> ();
				parvticalSystem.force = new Vector3 (0, 0f, 0);
				movePlayer = false;
				movePlayer = true;
//				UnderwaterBreatSource.Play ();
				StartCoroutine(UnderwaterBreatSourceSound(UnderwaterBreatSource));
				
				hanuThreadPOS = 0;
			}
		}
		else if (collider.gameObject.name == "ropeend") {
			try{
				ropehang = false;
				this.transform.gameObject.transform.FindChild("handle").parent = collider.gameObject.transform.parent.transform;;
				m_IsGrounded = true;
				m_Rigidbody.useGravity = true;
				m_Rigidbody.isKinematic = false;
				m_Animator.SetBool ("ropeslide", false);
				m_Rigidbody.transform.eulerAngles = euler0;

			}
			catch{}
		}
	}
	void OnTriggerExit(Collider collider) {
		
		if (collider.gameObject.name == "EndVine1") {
			
			if (collider.transform.position.y > transform.position.y) {
				
				isVineTouched = true;
				BGSoungTag = true;
				audioSource.Pause ();
//				swimAudioSource.clip = swimAudioAclip;
//				swimAudioSource.loop = true;
//				swimAudioSource.Play ();

				StartCoroutine(PlayWaterSound(swimAudioSource,swimAudioAclip));
				hanuThreadPOS = 2;
				
				babble1 = Instantiate (babble) as GameObject;
				parvticalSystem = babble1.GetComponent<ParticleAnimator> ();
				parvticalSystem.force = new Vector3 (0, 0f, 0);
				movePlayer = false;
//				UnderwaterBreatSource.Play ();
				StartCoroutine(UnderwaterBreatSourceSound(UnderwaterBreatSource));
				toggleTag = true;
			} 
		}
		else if (collider.gameObject.tag == "WaterSide") {

		
			try{
			collider.transform.GetChild(0).GetComponent<RealisticWater>().enabled = false;
			collider.transform.GetChild(1).GetComponent<RealisticWater>().enabled = false;
			collider.transform.GetChild(1).GetComponent<TI_Waves>().enabled = false;
			}catch{

			}

			try{
			GameObject go = (GameObject)collider.gameObject.transform.parent.parent.parent.gameObject;
			fish = go.transform.FindChild("fish").GetComponent<Fish> ();
			fish.fishTag = false;
			}catch{

			}
		}
		
		else if (collider.gameObject.name == "EndVine0") {
			MoveStopTag = true;
		}
		
		else if (collider.gameObject.name == "EndVine") {
			
			m_Rigidbody.isKinematic = false;
			clibStartTag = false;
			
			//m_IsGrounded = true;
			m_Animator.SetBool ("OnGround", m_IsGrounded);
			m_Rigidbody.useGravity = true;
			m_Animator.SetBool ("HangVine", false);
			hanglevel = 0;
			m_Animator.SetFloat ("jumpUpVine",0);
//			m_Animator.SetBool("jumpUpVineTag",false);
			m_Rigidbody.transform.eulerAngles = euler0;
			
		}
		
		else if (collider.gameObject.tag == "WaterTop") {
			
			if(clibStartTag){
			}
			else{
				
				
				if(PlayerState == 0){
					DisableTouchStick = true;
				}
				
				if(WaterEdge){
					movePlayer = false;
					EnableTouchStick = true;
					DisableTouchStick = false;
				}
				else{
//					movePlayer = true;
//					parvticalSystem.force = new Vector3(0,2.5f,0);
////					UnderwaterBreatSource.Play ();
////					FallInWaterAudoSource.clip = FallInWaterClip;
////					if(!FallInWaterAudoSource.isPlaying){
////						if(!isSwimStarted){
////							FallInWaterAudoSource.Play();
////						}
////					}
//					toggleTag = false;

					if(collider.transform.position.y < this.transform.position.y){
						movePlayer = false;
						EnableTouchStick = true;
						DisableTouchStick = false;
					}
					else{
						movePlayer = true;
						parvticalSystem.force = new Vector3(0,2.5f,0);
//						UnderwaterBreatSource.Play ();
						StartCoroutine(UnderwaterBreatSourceSound(UnderwaterBreatSource));


						FallInWaterAudoSource.clip = FallInWaterClip;
						if(!FallInWaterAudoSource.isPlaying){
							if(!isSwimStarted){
								FallInWaterAudoSource.Play();
//								StartCoroutine(PlayWaterSound(FallInWaterAudoSource,FallInWaterClip));
							}
						}
						toggleTag = false;

						m_Capsule.center = new Vector3 (0f, 0.08f, 0.0f);
						m_Capsule.height = 0.1f;
						m_Capsule.radius = 0.07f;
					}
				}
			}
		}
	}
	
	void OnTriggerStay(Collider collider) {
		
		if (collider.gameObject.tag == "WaterTop") {

			if(clibStartTag){
			}
			else{
				if (reduceFloat) {
					parvticalSystem.force = new Vector3 (0, 0f, 0);
					floatWater1 = Instantiate (floatWater) as GameObject;
					floatWater1.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
					reduceFloat = false;
				}
				if(!movePlayer1){
					movePlayer = false;
				}
				
				FallInWaterAudoSource.clip = SwimingrClip;
				FallInWaterAudoSource.volume = 0.5f;
				if(!FallInWaterAudoSource.isPlaying)
//					StartCoroutine(PlayWaterSound(FallInWaterAudoSource,SwimingrClip));
					FallInWaterAudoSource.Play();
//				UnderwaterBreatSource.Stop ();
				StartCoroutine(UnderwaterBreatSourceSound_STOP(UnderwaterBreatSource));
				toggleTag = true;
			}
		}
	}
}