﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

//this class is used to save character data between scene switches.  An object called GameController with this script attached is in every scene
public class GameController : MonoBehaviour {
	private Player yourPlayer;
	private Ally yourPartner;
	private int battleLoop;
	[SerializeField] private List<Sprite> sprites;
	[SerializeField] private List<Sprite> backgrounds;
	[SerializeField] private List<ParticleSystem> attackSpecialEffects;

	// Use this for initialization
	void Start () {
		//ensures the object's data is not erased between scenes
		DontDestroyOnLoad (this);
		battleLoop = 0;
	}
		
	public Player YourPlayer{
		get{ return yourPlayer; }
		set{ yourPlayer = value; }
	}
	public Ally YourPartner{
		get{ return yourPartner; }
		set{ yourPartner = value; }
	}

	public void SwitchScene (string nextScene)
	{
		SceneManager.LoadScene(nextScene);
	}
	public List<Sprite> Sprites{
		get{ return sprites; }
		set{sprites = value; }
	}
	public List<Sprite> Backgrounds{
		get{ return backgrounds; }
		set{backgrounds = value; }
	}
	public int BattleLoop{
		get{ return battleLoop; }
		set{battleLoop = value; }
	}

	public List<ParticleSystem> AttackSpecialEffects{
		get{ return attackSpecialEffects; }
		set { attackSpecialEffects = value; } 
	}

}
