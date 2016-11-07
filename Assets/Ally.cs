using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ally : Character{
	private const int STARTING_HP = 10;
	private int hp;
	private int rp;
	private int level;
	private int personalityType;
	private ClassType classType;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public override void Attack (){
		Debug.Log ("Ally is attacking");
		//disableUIButtonsForEnemyAttack
	}

	public void Heal(){
	}
	public void Block (){
	}

	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public int HP {
		get{ return hp; }
		set{ hp = value; } 

	}

	//applicable to player characters.  Defines relationship score between player and the ally
	int RP {
		get{ return rp; }
		set{ rp = value; }
	}

	//property for the level of the character.  This determines the stats of the player, the moves the player can have as well as the character stats
	int Level {
		get{return level;}
		set{ level = value; }
	}

	//Determines the weapon type of the character as well as dialogue variability
	int PersonalityType {
		get;
		set;
	}

	ClassType ClassType {
		get;
		set;
	}
}
