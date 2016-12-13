using UnityEngine;
using System.Collections;

//defines different actions which can be taken during battle. The characters will have 4 different actions which will be determined by class type
public abstract class Action {
	private int baseDamage;
	private string name;
	private int vulnerabilityDamage;
	private int effectDamage;
	private ParticleSystem particleEffect;


	public Action(string name, int baseDamage,ParticleSystem particleSystem) {
		Name = name;
		BaseDamage = baseDamage;
		ParticleEffect = particleSystem;
	}
	//base damage defines the initial amount of damage dealt by the moves
	public int BaseDamage {
		get{return baseDamage;}
		set{ baseDamage = value; }

	}
	//calculates the total damage done by a move depending on base damage and class Type
	public double CalculateDamage(Character attacker, Character defender, int battleCount){
		//get base damage of move 
		//add additional damage based on class of attacker and defender
		ActionBehavior();
		double damage =  baseDamage * attacker.Type.ClassEffectiveness[defender.Type.ClassName];
		if (damage < defender.EncourageCount) {
			damage = 0;
		} else {
			damage -= defender.EncourageCount;
		}
		if(damage != 0){
			damage += battleCount;
		}
		return damage;
	}
	//defines name of action
	public string Name{
		get{ return name; }
		set{ name = value; }
	}
	//defines name of action
	public int VulnerabilityDamage{
		get{ return vulnerabilityDamage; }
		set{ vulnerabilityDamage = value; }
	}
	//defines name of action
	public int EffectDamage{
		get{ return effectDamage; }
		set{ effectDamage = value; }
	}
	//defines name of action
	public ParticleSystem ParticleEffect{
		get{ return particleEffect; }
		set{ particleEffect = value; }
	}
	//Action behavior defines the overall affect of the action (any side effects - i.e. team attack brings up the team attack UI)
	public abstract void ActionBehavior();

	//defines any bonus damage determined by the attacker's class (type advantage)
	public int ClassDamageBonus(string typeName){
		return 0;
	}

}
