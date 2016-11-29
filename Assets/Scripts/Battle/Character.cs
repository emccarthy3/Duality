using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character{
	private const int STARTING_HP = 10;
	private double hp;
	private int rp;
	private int level;
	private string name;
	private List<Action> actions;
	private ClassType type;
	private Character nextPlayer;
	private Dictionary<int, ClassType> classTypesToPersonality;

	//the list of moves the battler has
	public List<Action> Actions {
		get{ return actions; }
		set{ actions = value; }

	}
	//the classtype of the battler (either warrior, mage, or ranger)
	public ClassType Type {
		get{ return type; }
		set{ type = value; }
	}
	//property for the level of the character.  This determines the stats of the player, the moves the player can have as well as the character stats
	public int Level {
		get{ return level; }	
		set{ level = value; }
	}
	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public double HP {
		get{return hp;}
		set{ hp = value; }

	}
	//more stats here

	public string Name {
		get{ return name; }
		set{ name = value; }
	}
	//applicable to player characters.  Defines relationship score between player and the ally
	public int RP {
		get{ return rp; }
		set{ rp = value; }
	}

	public void GetClassTypeFromHashtable(int personality){
		classTypesToPersonality = new Dictionary<int, ClassType> ();
		classTypesToPersonality.Add (1, new Warrior (this));
		classTypesToPersonality.Add (2, new Magician (this));
		classTypesToPersonality.Add (3, new Ranger (this));
		Type = classTypesToPersonality[personality];
	}
		
}
