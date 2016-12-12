using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Magician : ClassType {
	public Dictionary<string, double> classEffectiveness;

	public Magician(){
		ClassName = "Magician";
		Actions = DefaultActions();
	}


	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Fire bolt", 1));
		defaultActions.Add (new StrongAttack ("Earthquake",3));
		defaultActions.Add (new StatusEffectAttack ("Water wave", 1,1));
		defaultActions.Add (new VulnerabilityAttack ("Mind boggle",0));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", .5);
		ClassEffectiveness.Add ("Magician", 1);
		ClassEffectiveness.Add ("Warrior", 2);
	}
}
