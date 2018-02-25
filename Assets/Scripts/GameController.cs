using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static GameController Instance {get; private set; }
	static bool created = false;

	public float timePerTile = 1.0f;
	private float lastTileTime = 0;

	public GameObject tileObject;
	public Transform tileTransform;

	public UnityEngine.UI.Text timeText;

	private float time;
	private float elapsedTime;

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

	// Use this for initialization
	void Start () 
	{
		time = 0;
		elapsedTime = 0;
	}

	void Update () 
	{
		time = Time.time - elapsedTime;
		timeText.text = "Time: " + time.ToString("N");

		if (time > lastTileTime)
		{
			lastTileTime = time + timePerTile;
			GameObject.Instantiate(tileObject, tileTransform);
		}
	}

	public void RestartLevel()
	{
		foreach(Transform t in tileTransform)
		{
			Destroy(t.gameObject);
		}

		elapsedTime = Time.time;
		lastTileTime = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
