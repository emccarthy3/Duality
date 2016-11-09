using UnityEngine;
using System.Collections;


public abstract class Action {
	private int baseDamage;
	private Hashtable warriorTypeEffectiveness;
	private string name;

	public int BaseDamage {
		get{return baseDamage;}
		set{ baseDamage = value; }

	}

	public int CalculateDamage(Character attacker, Character defender){
		//get base damage of move 
		//add additional damage based on class of attacker and defender

		return baseDamage;
	}

	public string Name{
		get{ return name; }
		set{ name = value; }
	}
	public abstract void ActionBehavior();

	public int ClassDamageBonus(){
		return 0;
	}

}
