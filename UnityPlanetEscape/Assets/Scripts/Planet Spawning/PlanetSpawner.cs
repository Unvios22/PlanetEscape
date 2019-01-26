using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Planet_Spawning {
	public class PlanetSpawner : MonoBehaviour {
		public List<GameObject> PlanetPrefabsList;
		[SerializeField] private List<Transform> spawnRootPoints = new List<Transform>();
		[SerializeField] private GameObject target;
		[SerializeField] private float spawnRandomness = 1;
		[SerializeField] private float planetSpeed = 1f;

		private void Start() {
			OnValidate();
		}

		public void SpawnPlanet() {
			//get random root from the attached root positions
			var spawnRoot = spawnRootPoints[Random.Range(0, spawnRootPoints.Count)];
			
			//randomize position somewhere around the chosen root
			var spawnPoint = Random.insideUnitCircle * spawnRandomness + (Vector2)spawnRoot.position;
			
			var planet = Instantiate(GetRandomPlanetPrefab(), spawnPoint, Quaternion.identity);
			MovePlanetTowardsTarget(planet); 
		}

		private GameObject GetRandomPlanetPrefab() {
			return PlanetPrefabsList[Random.Range(0, PlanetPrefabsList.Count)];
		}
		
		private void MovePlanetTowardsTarget(GameObject planet) {
			var targetPosition = GetPositionNearTarget();
			var heading = targetPosition - planet.transform.position;
			var distance = heading.magnitude;
			var direction = heading / distance;
			
			planet.GetComponent<Rigidbody>().AddForce(direction * planetSpeed);
		}

		private Vector3 GetPositionNearTarget() {
			var position = Random.insideUnitCircle + (Vector2)target.transform.position;
			return position;
		}

		private void OnValidate() {
			if (spawnRandomness < 1) {
				spawnRandomness = 1;
			}
		}
	}
}