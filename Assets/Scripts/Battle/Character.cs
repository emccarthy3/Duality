using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character{
	private const int STARTING_HP = 10;
	private double hp;
	private int rp;
	private string name;
	private int personalityType;
	private int healCount;
	private ClassType type;
	private Character nextPlayer;
	private Dictionary<int, ClassType> classTypesToPersonality;
	private Sprite playerSprite;
	private bool hasEffectDamage = false;
	private int encourageCount =0;
	private State isBlockingState;
	private HealState isAbleToHealState;

	//the classtype of the battler (either warrior, mage, or ranger)
	public ClassType Type {
		get{ return type; }
		set{ type = value; }
	}

	//property for health points of characters.  Health points increase for the player and the ally during level ups and increase for enemies in between battles
	public double HP {
		get{return hp;}
		set{ hp = value; }
	}

	public string Name {
		get{ return name; }
		set{ name = value; }
	}
	//applicable to player characters.  Defines relationship score between player and the ally
	public int RP {
		get{ return rp; }
		set{ rp = value; }
	}

	public int PersonalityType {
		get{ return personalityType; }
		set{ personalityType = value; }
	}
	public Sprite PlayerSprite {
		get{ return playerSprite; }
		set{ playerSprite = value; }
	}
	public bool HasEffectDamage{
		get{ return hasEffectDamage; }
		set{ hasEffectDamage = value; }
	}
		
	public State IsBlockingState{
		get{ return isBlockingState; }
		set{ isBlockingState = value; }
	}

	public HealState IsAbleToHealState{
		get{ return isAbleToHealState; }
		set{ isAbleToHealState = value; }
	}
	public int HealCount{
		get{ return healCount; }
		set{ healCount = value; }
	}
	public int EncourageCount{
		get{ return encourageCount; }
		set{ encourageCount = value; }
	}

}
