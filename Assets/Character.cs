using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character: MonoBehaviour{
	private const int STARTING_HP = 10;
	private int hp;
	private int rp;
	private int level;
	private int personalityType;
	private List<Moves> moves;
	private ClassType classType;


	//determines action taken during battler's turn
	public abstract void Attack ();



	//the list of moves the battler has
	public List<Moves> Moves {
		get{ return moves; }
		set{ moves = value; }

	}
	//the classtype of the battler (either warrior, mage, or ranger)
	ClassType ClassType {
		get;
		set;
	}
	//property for the level of the character.  This determines the stats of the player, the moves the player can have as well as the character stats
	int Level {
		get{ return level; }
	
		set{ level = value; }
	}
	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public int HP {
		get{return hp;}
		set{ hp = value; }

	}
	//more stats here



	//applicable to player characters.  Defines relationship score between player and the ally
	public int RP {
		get{ return rp; }
		set{ rp = value; }
	}



	//Determines the weapon type of the character as well as dialogue variability
	public int PersonalityType {
		get{ return personalityType; }
		set{personalityType =value;}
	}
}
