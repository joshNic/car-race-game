using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {
	public float carSpeed;
	//public float minPos;
	public float maxPos = 2.1f;
	Vector3 position;
	public  manager ui;
	public audio am;
	bool currentPlatform = false;
	Rigidbody2D rb;

	// Use this for initialization

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		am.carSound.Play ();
#if UNITY_ANDROID
		currentPlatform = true;
#else
		currentPlatform = false;
#endif

	}
	void Start () {

		position = transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentPlatform == true) {
			//Android Specific Code

			//TouchMove();
			AccelerometerMove();

		} else {
			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
			
			position.x = Mathf.Clamp (position.x, -2.1f, 2.1f);
			transform.position = position;
		}
		position = transform.position; 
		position.x = Mathf.Clamp (position.x, -2.1f, 2.1f);
		transform.position = position;

	
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy car"){
			//Destroy (gameObject);
			gameObject.SetActive(false);
			ui.gameOverActivated();
			am.carSound.Stop();
		}
	}

	void AccelerometerMove(){
		float x = Input.acceleration.x;
		if (x < -0.2f) {
			moveLeft ();
		} else if (x > 0.2f) {
			moveRight ();
		} else {
			zeroVelocity();
		}

	}
	void TouchMove(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;
			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				moveLeft ();

			} else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				moveRight ();
				
			} 
		} else {
			zeroVelocity();
		}
	}

	public void moveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);

	}
	public void moveRight(){
		rb.velocity = new Vector2 (carSpeed, 0);

	}
	public void zeroVelocity(){
		rb.velocity = Vector2.zero;

	}
}
