using System.Collections;
using System.Collections.Generic;
using ReadonlyData;
using Ship;
using Shooting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public PlayerPlanet currentPlanet;
	public float planetProgress;
	public float resources;
	public float population;
	public float food;
	public UIScript UiScript;
	private float resourcesMultiplierFactor = 80f;
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
	private GameObject shipLogic;

	[SerializeField] private GameObject gunGameObject;

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
		currentPlanet.gameController = this;
//		currentPlanet.transform.position = gunGameObject.transform.position;
//		shipControls.gameObject.transform.position = currentPlanet.transform.position;
		PlanetStageEvent();
	}

	public void FreezeTime() {
		Time.timeScale = 0f;
	}

	public void UnFreezeTime() {
		Time.timeScale = 1;
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
		StartShip();
		StopAllCoroutines();
		StartCoroutine(Eat());
		shipGameObject.GetComponent<Renderer>().enabled = true;
		shipGameObject.GetComponent<Collider2D>().enabled = true;
		planetShooterGameObject.SetActive(false);
		stage = GameStage.Ship;
		DisposeOfCurrentPlanet();
		StartCoroutine(ShipStage());
	}

	private void DisposeOfCurrentPlanet()
	{
		currentPlanet.gameObject.GetComponent<Collider2D>().enabled = false;
		var randomDirection = new Vector2(Random.Range(0f, 360f), Random.Range(0f, 360f));
		currentPlanet.GetComponent<Rigidbody2D>().AddForce(randomDirection * 15f, ForceMode2D.Force);
	}

	private void OnPlanetStageStart() {
		GiveThemFood(100);
		StopAllCoroutines();
		StartCoroutine(AddPopulation());
		StartCoroutine(AddResources());
		StartCoroutine(Eat());
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
//			planetControls.ReadControls();
			if (Input.GetKey(KeyCode.E)) {
				//todo: test against some variables and subtract some of them - so  that launching the ship acually costs something
				ShipStageEvent();
			}

			if (Input.GetKeyDown(KeyCode.F) && !UiScript.isUIOpen) {
				UiScript.OpenWindow();
			}
			else if (Input.GetKeyDown(KeyCode.F) && UiScript.isUIOpen) {
				UiScript.CloseWindow();
			}

			yield return null;
		}
	}

	private IEnumerator AddResources() {
		for (;;) {
			resources++;
			yield return new WaitForSeconds(resourcesMultiplierFactor / population);
		}
	}

	private IEnumerator AddPopulation() {
		for (;;) {
			if (food > 0 && stage == GameStage.Planet)
				Population++;
			else if (food <= 0 && Population >= 0) {
				Population -= 19;
				if (Population < 0) {
					Population = 0;
				}
			} //todo maybe random here?

			if (Population <= 0)
				SceneManager.LoadScene("GameOver"); 
			yield return new WaitForSeconds(2f);
		}
	}


	private IEnumerator DifficultyIncrease() {
		var counter = 0f;
		for (;;) {
			if (counter >= difficultyTimeIncrease) {
				counter = 0;
				asteroidSpawner.asteroidMaxAmount++;
			}

			counter += Time.deltaTime;
			yield return null;
		}
	}

	private IEnumerator FuelIncrease() {
		//todo hook up reference to ship and ioncrease its fuel by time.delta time every frame
		yield return null;
	}

	void GiveThemFood(float amount) {
		food = amount;
	}

	private IEnumerator Eat() {
		for (;;) {
			if (food > 0)
				food--;
			yield return new WaitForSeconds(2f - (population / 100));
		}
	}

	private void StartShip() {
		if (population > shipControls.maxPplOnBoard)
			population = shipControls.maxPplOnBoard;
		shipControls.CurrentFuel1 -= 40f;
		//todo im więcej osób na pokładzie, tym droższy start (minimalnie)
	}

	public float Resources {
		get { return resources; }
		set {
			if (value < 0) {
				resources = 0;
			}
			else {
				resources = value;
			}
		}
	}

	public float Population {
		get { return population; }
		set {
			if (value < 0) {
				population = 0;
			}
			else {
				population = value;
			}
		}
	}

	public float Food {
		get { return food; }
		set {
			if (value < 0) {
				food = 0;
			}
			else {
				food = value;
			}
		}
	}
}