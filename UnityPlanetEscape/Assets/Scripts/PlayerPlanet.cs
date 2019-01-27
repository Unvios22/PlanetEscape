using System;
using AsteroidMechanic;
using ReadonlyData;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerPlanet : MonoBehaviour {
	//todo attach to player planet gameobject

	public GameController gameController;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag(Tags.ASTEROID)) {
			//todo
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.ASTEROID)) {
			other.GetComponent<Asteroid>().DestroyAsteroid();
			//todo minus population, and resources
			gameController.population -= Random.Range(5f, 30f);
			gameController.resources -= Random.Range(5f, 30f);
		}
	}
}