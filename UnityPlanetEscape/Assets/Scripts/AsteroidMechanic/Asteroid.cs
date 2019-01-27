using UnityEngine;

namespace AsteroidMechanic {
	public class Asteroid : MonoBehaviour {
		public float speed = 10.0f;
		public float destroyOnDistanceToPlanet;
		public GameObject planet;
		private Rigidbody2D _rigidbody2D;
		public AsteroidSpawner asteroidSpawner;

		void Start() {
			_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
			_rigidbody2D.AddForce(Random.insideUnitCircle * speed * Random.Range(0.6f,1f),ForceMode2D.Impulse);
		}

		void Update() {
			if (DistanceToPlanet(transform.position) > destroyOnDistanceToPlanet) {
				GameObject.FindObjectOfType<AsteroidSpawner>().asteroidAmount--;
				DestroyAsteroid();
			}
		}
	
		public void DestroyAsteroid() {
			asteroidSpawner.asteroidAmount--;
			Destroy(gameObject);
		}

		private float DistanceToPlanet(Vector3 position) {
			return Vector3.Distance(position, planet.transform.position);
		}
	}
}