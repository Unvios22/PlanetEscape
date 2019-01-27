using System.Collections;
using System.Collections.Generic;
using ReadonlyData;
using Ship;
using UnityEngine;

public class GameController : MonoBehaviour {
	public PlayerPlanet currentPlanet;
	public float planetProgress;
	public float resources;
	public float population;
	public float food;
	public GameStage stage;
	[SerializeField] private AsteroidSpawner asteroidSpawner;
	[SerializeField] private float difficultyTimeIncrease = 2f;
	//lower means harder

	[SerializeField] private GameObject screenCenter;
	[SerializeField] private List<GameObject> PlanetPrefabsList = new List<GameObject>();
	[SerializeField] private ShipLogic shipControls;
	[SerializeField] private ShootingFromPlanet planetControls;
	[SerializeField] private GameObject shipGameObject;
	[SerializeField] private GameObject planetShooterGameObject;
	

	private delegate void GameStageChangeDelegate();
	private event GameStageChangeDelegate ShipStageEvent;
	private event GameStageChangeDelegate PlanetStageEvent;

	public enum GameStage {
		Planet,
		Ship
	}

	public void ColonizePlanet(GameObject planet) {
		currentPlanet = planet.AddComponent<PlayerPlanet>();
		currentPlanet.tag = Tags.PLAYER_PLANET;
		currentPlanet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		PlanetStageEvent();

	}

	private void Start() {
		InitializeStaringPlanet();
	}

	private void InitializeStaringPlanet() {
		var startingPlanet = Instantiate(PlanetPrefabsList[Random.Range(0, PlanetPrefabsList.Count)]);
		startingPlanet.transform.position = screenCenter.transform.position;
		ColonizePlanet(startingPlanet);
	}

	private void OnEnable() {
		
		ShipStageEvent += OnShipStageStart;
		PlanetStageEvent += OnPlanetStageStart;
	}

	private void OnDisable() {
		ShipStageEvent -= OnShipStageStart;
		PlanetStageEvent -= OnPlanetStageStart;
	}

	private void OnShipStageStart() {
		StopAllCoroutines();
		shipGameObject.GetComponent<Renderer>().enabled = true;
		shipGameObject.GetComponent<Collider2D>().enabled = true;
		planetShooterGameObject.SetActive(false);
		stage = GameStage.Ship;
		DisposeOfCurrentPlanet();
		StartCoroutine(ShipStage());
	}

	private void DisposeOfCurrentPlanet() {
		var randomDirection = new Vector2(Random.Range(0f,360f), Random.Range(0f,360f));
		currentPlanet.GetComponent<Rigidbody2D>().AddForce(randomDirection * 15f, ForceMode2D.Force);
	}

	private void OnPlanetStageStart() {
		GiveThemFood(100);
		StopAllCoroutines();
		shipGameObject.GetComponent<Renderer>().enabled = false;
		shipGameObject.GetComponent<Collider2D>().enabled = false;
		shipGameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		planetShooterGameObject.SetActive(true);
		stage = GameStage.Planet;
		StartCoroutine(PlanetStage());
	}

	private IEnumerator ShipStage() {
		for (;;) {
			shipControls.ReadControls();
			yield return null;
		}
	}

	private IEnumerator PlanetStage() {
		asteroidSpawner.asteroidMaxAmount = 25;
		StartCoroutine(DifficultyIncrease());
		for (;;) {
			planetControls.ReadControls();
			if (Input.GetKey(KeyCode.E)) {
			//todo: test against some variables and subtract some of them - so  that launching the ship acually costs something
			ShipStageEvent();
			}
			yield return null;
		}

	}

	private IEnumerator DifficultyIncrease() {
		var counter = 0f;
		for (;;) {
			if (counter >= difficultyTimeIncrease) {
				counter = 0;
				asteroidSpawner .asteroidMaxAmount++;
			}
			counter += Time.deltaTime;
			yield return null;
		}
	}

	private IEnumerator FuelIncrease() {
		//todo hook up reference to ship and ioncrease its fuel by time.delta time every frame
		yield return null;
	}

	void GiveThemFood(float amount)
	{
		food = amount;
	}


}