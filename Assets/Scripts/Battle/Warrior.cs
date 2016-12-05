using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines warrior class
public class Warrior : ClassType {

	public Warrior(){
		ClassName = "Warrior";
		Actions = DefaultActions();
	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Slash", 1));
		defaultActions.Add (new TeamAttack ("Team attack" , 1));
		defaultActions.Add (new SingleAttack ("Stab", 1));
		defaultActions.Add (new SingleAttack ("Slice",1));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 2);
		ClassEffectiveness.Add ("Magician", .5);
		ClassEffectiveness.Add ("Warrior", 1);
	}

}
