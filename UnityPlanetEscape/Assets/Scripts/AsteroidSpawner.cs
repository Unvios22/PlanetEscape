using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidSpawner : MonoBehaviour {
	[SerializeField] private List<GameObject> asteroidPrefabsList = new List<GameObject>();
	[FormerlySerializedAs("planet")] [SerializeField] private GameObject spawnCenter;
	[SerializeField] private int asteridMaxAmount = 25;
	[SerializeField] private float minimalDistanceToPlanet = 5f;
	[SerializeField] private float maxDistanceToPlanet = 5f;
	[SerializeField] private float asteroidSpawnRadius = 30f;
	[SerializeField] private float asteroidSpeed = 20f;
	public int asteroidAmount;

	private void Start() {
		StartCoroutine(SpawnAsteroids());
	}

	IEnumerator SpawnAsteroids() {
		for(;;) {
			if (asteroidAmount < asteridMaxAmount) {
				SpawnAsteroid();
				asteroidAmount++;
			}
			yield return null;
		}
	}
	
	private void SpawnAsteroid() {
		Vector2 spawnPoint = Random.insideUnitCircle * 20;
		while (DistanceToPlanet(spawnPoint) < minimalDistanceToPlanet) {
			spawnPoint = Random.insideUnitCircle * asteroidSpawnRadius;
		}
		var asteroid =  Instantiate(getRandomAsteroidFromList(), spawnPoint, Quaternion.identity);
		var asteroidScript = asteroid.GetComponent<Asteroid>();
		asteroidScript.destroyOnDistanceToPlanet = maxDistanceToPlanet;
		asteroidScript.speed = asteroidSpeed;
		asteroidScript.planet = spawnCenter;
	}

	private GameObject getRandomAsteroidFromList() {
		return asteroidPrefabsList[Random.Range(0, asteroidPrefabsList.Count)];
	}
	
	private float DistanceToPlanet(Vector3 position) {
		return Vector3.Distance(position, spawnCenter.transform.position);
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		var position = transform.position;
		Gizmos.DrawWireSphere(position, maxDistanceToPlanet);
		Gizmos.DrawWireSphere(position, minimalDistanceToPlanet);
	}
}