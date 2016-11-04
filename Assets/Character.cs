using UnityEngine;
using System.Collections;

public abstract class Character {
	private const int STARTING_HP = 10;
	private ClassType classType;
	private int maxHP;
	private int hp;
	private int rp;
	//more stats here

	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public int HP{
		get{ return hp; }
		set { hp = value; }
	
	}

	//applicable to player characters.  Defines relationship score between player and the ally
	public int RP{
		get{ return rp; }
		set { rp = value; }
	}

	//property for the level of the character.  This determines the stats of the player, the moves the player can have as well as the character stats
	public abstract void Level();

	//Determines the weapon type of the character as well as dialogue variability
	public int PersonalityType(){
		return 0;
	}

	public ClassType ClassType {
		get{ return classType; }
		set { ClassType = value; }
	}

}
