using UnityEngine;
using System.Collections;

//defines different actions which can be taken during battle. The characters will have 4 different actions which will be determined by class type
public abstract class Action {
	private int baseDamage;
	private Hashtable warriorTypeEffectiveness;
	private string name;

	//base damage defines the initial amount of damage dealt by the moves
	public int BaseDamage {
		get{return baseDamage;}
		set{ baseDamage = value; }

	}
	//calculates the total damage done by a move depending on base damage and class Type
	public int CalculateDamage(Character attacker, Character defender){
		//get base damage of move 
		//add additional damage based on class of attacker and defender

		return baseDamage;
	}
	//defines name of action
	public string Name{
		get{ return name; }
		set{ name = value; }
	}
	//Action behavior defines the overall affect of the action (any side effects - i.e. team attack brings up the team attack UI)
	public abstract void ActionBehavior();

	//defines any bonus damage determined by the attacker's class (type advantage)
	public int ClassDamageBonus(){
		return 0;
	}

}
