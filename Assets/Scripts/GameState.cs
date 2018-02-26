using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameState : MonoBehaviour 
{
	static readonly GameState instance = new GameState();

	public static GameState Instance
	{
		get
		{
			return instance;
		}
	}

	static GameState() { }
	private GameState() { }

	public enum State { Title, Playing, Paused };
	private State state;

	public State GetState()
	{
		return state;
	}

	public void SetState(State s)
	{
		state = s;
	}

}
