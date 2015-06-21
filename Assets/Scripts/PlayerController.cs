using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int Num;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCount ();
		winText.text = "";
	}

	public void OnMyNewButtonClick() {
		//Application.Quit ();
		Application.LoadLevel (0); 
		//Application.Quit;
	}
	// Update is called once per frame
	//void Update () {
	//
	//}

	// FixedUpdate is called before performing any physics calculations
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal") +
			Input.acceleration.x;
		float moveVertical = Input.GetAxis ("Vertical") +
			Input.acceleration.y;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0F, moveVertical);
		rb.AddForce (movement * speed);
	}

	// Destroy everything that enters the trigger
	void OnTriggerEnter (Collider other) {
		//Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			setCount ();
		}
	}

	void setCount() {
		countText.text = "Count: " + count.ToString ();
		if (count >= Num) {
			winText.text = "You Win!";
		}
	}

}
