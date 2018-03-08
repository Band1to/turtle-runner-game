using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance {get; private set; }
	static bool created = false;

	public float timePerTile = 0.4f;
	private float lastTileTime = 0;

	public GameObject tileObject;
	public Transform tileTransform;

	public UnityEngine.UI.Text timeText;

	private float time;
	private float elapsedTime;

	//Pause Screen
	public GameState gameState;
	public GameObject pauseScreen;
	private float lastPausedTime;
	private float elapsedPauseTime;

	public bool turtleHiding;

	void Awake()
	{
		if (!created)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void ResetTime()
	{
		time = 0;
		elapsedTime = 0;
		lastPausedTime = 0;
		elapsedPauseTime = 0;
		lastTileTime = 0;
	}

	// Use this for initialization
	void Start () 
	{
		ResetTime();
		gameState.SetState(GameState.State.Playing);
	}

	void Update () 
	{
		if (gameState.GetState() != GameState.State.Playing)
			return;

		time = Time.time - elapsedTime - elapsedPauseTime;
		timeText.text = "Time: " + time.ToString("N");

		if (time > lastTileTime)
		{
			lastTileTime = time + timePerTile;
			GameObject.Instantiate(tileObject, tileTransform);
		}
	}

	public void SetPaused()
	{
		lastPausedTime = Time.time;
		pauseScreen.SetActive(true);
		gameState.SetState(GameState.State.Paused);
	}

	public void SetPlaying()
	{
		elapsedPauseTime = Time.time - lastPausedTime;
		time = Time.time - elapsedPauseTime;

		pauseScreen.SetActive(false);
		gameState.SetState(GameState.State.Playing);
	}

	public void RestartLevel()
	{
		foreach(Transform t in tileTransform)
		{
			Destroy(t.gameObject);
		}

		ResetTime();

		elapsedTime = Time.time;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
