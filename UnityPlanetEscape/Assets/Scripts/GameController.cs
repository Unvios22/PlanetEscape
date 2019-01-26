using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float planetProgress;
	public GameStage stage;
	[SerializeField] private AsteroidSpawner asteroidSpawner;
	[SerializeField] private float difficultyTimeIncrease = 2f;
	//lower means harder

	private delegate void GameStageChangeDelegate();
	private event GameStageChangeDelegate ShipStageEvent ;
	private event GameStageChangeDelegate PlanetStageEvent;

	public enum GameStage {
		Planet,
		Ship
	}

	private void Start() {
		PlanetStageEvent();
	}

	private void OnEnable() {
		
		ShipStageEvent += OnShipStage;
		PlanetStageEvent += OnPlanetStage;
	}

	private void OnDisable() {
		ShipStageEvent -= OnShipStage;
		PlanetStageEvent -= OnPlanetStage;
	}

	private void OnShipStage() {
		StopAllCoroutines();
		StartCoroutine(ShipStage());
	}

	private void OnPlanetStage() {
		StopAllCoroutines();
		StartCoroutine(PlanetStage());
	}

	private IEnumerator ShipStage() {
		for (;;) {
			//todo: podpiac sterowanie statkiem
		}
	}

	private IEnumerator PlanetStage() {
		asteroidSpawner.asteroidMaxAmount = 25;
		StartCoroutine(DifficultyIncrease());
		for (;;) {
			//todo: podpiac sterowanie dzialkiem na planecie; jesli paliwo jest pelne, i gracz nacisnie e, to wystrzel
			//statek zamiast nastepnego pocisku i przelacz na tryb statku
		}

	}

	private IEnumerator DifficultyIncrease() {
		var counter = 0f;
		for (;;) {
			if (counter >= difficultyTimeIncrease) {
				counter = 0;
				asteroidSpawner.asteroidMaxAmount++;
			}
		}
	}

	private IEnumerator FuelIncrease() {
		//todo hook up reference to ship and ioncrease its fuel by time.delta time every frame
		yield return null;
	}


}