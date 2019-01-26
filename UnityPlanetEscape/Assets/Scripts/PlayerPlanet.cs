using System;
using ReadonlyData;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour {
	[Range(0f,100f)]
	public float health = 100f;
	[SerializeField] private float asteroidDamage;
	//todo attach to player planet gameobject

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag(Tags.ASTEROID)) {
			health--;
		}
	}

	private void Update() {
		if (health <= 0) {
			Debug.Log("You died.");
			//todo implement dying mechanic
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.ASTEROID)) {
			other.GetComponent<Asteroid>().DestroyAsteroid();
			health -= asteroidDamage;
		}
	}
}