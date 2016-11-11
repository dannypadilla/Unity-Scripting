using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	private float _timeRemaining;

	public float TimeRemaining {
		get { return _timeRemaining; }
		set { _timeRemaining = value; }
	}

	private int _numCoins;

	public int NumCoins {
		get { return _numCoins; }
		set { _numCoins = value; }
	}

	private float _playerHealth;

	public float PlayerHealth {
		get { return _playerHealth; }
		set { _playerHealth = value; }
	}

	private float maxTime = 5 * 60; // In seconds
	private int maxHealth = 3;

	// Use this for initialization
	void Start () {
		TimeRemaining = maxTime;
		PlayerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		TimeRemaining -= Time.deltaTime;

		if(TimeRemaining <= 0) {
			// Application.LoadLevel (Application.loadedLevel); // This is obsolete, but still works...
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			TimeRemaining = maxTime;
			PlayerHealth = maxHealth;
		}
	}

	void DecrementPlayerHealth(GameObject player) {
		PlayerHealth--;
		if (PlayerHealth <= 0) {

		}
	}

	private void Restart() {
		
	}
}
