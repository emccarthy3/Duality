using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ranger : ClassType {

	public Ranger(){
		ClassName = "Ranger";
		Actions = DefaultActions();
	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Shoot Arrow", 1));
		defaultActions.Add (new StrongAttack ("Chuck Rock",3));
		defaultActions.Add (new StatusEffectAttack ("Sharpshoot", 1,1));
		defaultActions.Add (new VulnerabilityAttack ("Taunt",0));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 1);
		ClassEffectiveness.Add ("Magician", 2);
		ClassEffectiveness.Add ("Warrior", .5);
	}
}
