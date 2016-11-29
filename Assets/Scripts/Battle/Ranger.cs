using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ranger : ClassType {

	public Ranger(Character ranger){
		ClassName = "Ranger";
		ranger.Actions = DefaultActions();

	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Shoot Arrow", 1));
		defaultActions.Add (new TeamAttack ("Team attack" , 1));
		defaultActions.Add (new SingleAttack ("Throw knife", 1));
		defaultActions.Add (new SingleAttack ("Chuck Rock",1));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 1);
		ClassEffectiveness.Add ("Magician", 2);
		ClassEffectiveness.Add ("Warrior", .5);
	}
}
