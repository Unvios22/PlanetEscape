using System.Collections;
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
	
	[SerializeField] private ShipLogic shipControls;
	[SerializeField] private ShootingFromPlanet planetControls;
	[SerializeField] private GameObject shipGameObject;
	[SerializeField] private GameObject playerPlanetGameObject;
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
		shipGameObject.GetComponent<Renderer>().enabled = true;
		shipGameObject.GetComponent<Collider2D>().enabled = true;
		planetShooterGameObject.SetActive(false);
		stage = GameStage.Ship;
		StartCoroutine(ShipStage());
	}

	private void OnPlanetStage() {
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


}