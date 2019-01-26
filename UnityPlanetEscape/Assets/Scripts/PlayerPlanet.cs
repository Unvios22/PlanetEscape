using ReadonlyData;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour {
	public int health = 5;
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
}