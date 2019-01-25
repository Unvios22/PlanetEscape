using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	[SerializeField] private float spawnStartYValue;
	[SerializeField] private float spawnStopYValue;
	[SerializeField] private float spawnInteval;

	private void Start() {
		StartCoroutine(SpawnPlanets());
	}

	private IEnumerator SpawnPlanets() {
		var counter = 0f;
		for (;;) {
			if (counter >= spawnInteval) {
				SpawnPlanet();
				counter = 0;
			}
			counter += Time.deltaTime;
		}
	}

	private void SpawnPlanet() {
		
	}
}