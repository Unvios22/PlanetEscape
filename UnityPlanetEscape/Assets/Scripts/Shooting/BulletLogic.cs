using System;
using ReadonlyData;
using UnityEngine;

namespace Shooting {
	public class BulletLogic : MonoBehaviour {
		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.CompareTag(Tags.ASTEROID)) {
				other.GetComponent<Asteroid>().DestroyAsteroid();
			}
		}
	}
}