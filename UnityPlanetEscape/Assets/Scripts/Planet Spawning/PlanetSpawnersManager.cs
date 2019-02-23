using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Planet_Spawning {
	public class PlanetSpawnersManager : MonoBehaviour {
		[SerializeField] private float spawnInterval;
		[SerializeField] private List<PlanetSpawner> planetSpawnersList;
		[SerializeField] private List<GameObject> PlanetPrefabsList = new List<GameObject>();
		private void Start() {
			OnValidate();
			StartCoroutine(SpawnPlanets());
			InitializePlanetSpawners();
		}

		private void InitializePlanetSpawners() {
			foreach (var spawner in planetSpawnersList) {
				spawner.PlanetPrefabsList = PlanetPrefabsList;
			}
		}

		private IEnumerator SpawnPlanets() {
			var counter = 0f;
			for (;;) {
				if (counter >= spawnInterval) {
					SpawnPlanet();
					counter = 0;
				}
				counter += Time.deltaTime;
				yield return null;
			}
		}

		private void SpawnPlanet() {
			//get random planet spawner
			var spawner = planetSpawnersList[Random.Range(0, planetSpawnersList.Count)];
			spawner.SpawnPlanet();
		}

		private void OnValidate() {
			if (spawnInterval < 0.1f) {
				spawnInterval = 0.1f;
			}
		}
	}
}