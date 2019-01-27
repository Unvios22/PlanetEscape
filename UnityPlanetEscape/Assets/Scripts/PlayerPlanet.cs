using System;
using AsteroidMechanic;
using ReadonlyData;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour {
	
	
	

	
	//todo attach to player planet gameobject

	private void Start() {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag(Tags.ASTEROID)) {
			//todo
		}
	}

	private void Update() {
		
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.ASTEROID)) {
			other.GetComponent<Asteroid>().DestroyAsteroid();
			//todo minus population, and resources
		}
	}
}