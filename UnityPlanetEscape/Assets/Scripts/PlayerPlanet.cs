using System;
using AsteroidMechanic;
using ReadonlyData;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerPlanet : MonoBehaviour {
	//todo attach to player planet gameobject

	public GameController gameController;
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.ASTEROID)) {
			other.GetComponent<Asteroid>().DestroyAsteroid();
			//minus pop and resources on collision with asteroid
			gameController.population -= Random.Range(10f, 40f);
			gameController.resources -= Random.Range(10f, 40f);
		}
	}
}