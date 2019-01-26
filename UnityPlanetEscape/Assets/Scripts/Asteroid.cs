using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float speed = 10.0f;
	public float destroyOnDistanceToPlanet;
	[SerializeField] private GameObject planet;
	private Rigidbody _rigidbody;

	void Start() {
		_rigidbody = gameObject.GetComponent<Rigidbody>();
		_rigidbody.AddForce(Random.insideUnitCircle * speed * Random.Range(0.6f,1f),ForceMode.Impulse);
	}

	void Update() {

		if (DistanceToPlanet(transform.position) > destroyOnDistanceToPlanet) {
			GameObject.FindObjectOfType<AsteroidSpawner>().asteroidAmount--;
			Destroy(gameObject);
		}
	}
	private float DistanceToPlanet(Vector3 position) {
		return Vector3.Distance(position, planet.transform.position);
	}
}