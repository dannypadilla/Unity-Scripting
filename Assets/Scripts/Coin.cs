using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	[SerializeField]
	private float rotateSpeed = 1.0f; // In rotations per second

	[SerializeField]
	private float floatSpeed = 0.5f; // In cycles (up and down) per second

	[SerializeField]
	private float movementDistance = 0.5f; // The max distance the coin can move up and down

	private float startingY;
	private bool isMovingUp = true;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			Pickup ();
		}
	}

	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		transform.Rotate (transform.up, Random.Range (0f, 360f));
	}

	void Update() {
		Spin ();
		Float ();
	}

	private void Pickup() {
		GameManager.Instance.NumCoins++;
		Destroy (gameObject);
	}

	private void Spin() {
		transform.Rotate (transform.up, Time.deltaTime * rotateSpeed * 360);
	}

	private void Float() {
		float newY = transform.position.y + (isMovingUp ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;
		if (newY > startingY + movementDistance) {
			newY = startingY + movementDistance;
			isMovingUp = false;
		} else if (newY < startingY) {
			newY = startingY;
			isMovingUp = true;
		}
		transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
	}

}
