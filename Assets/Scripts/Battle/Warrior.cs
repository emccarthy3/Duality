using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warrior : ClassType {

	public Warrior(Character warrior){
		ClassName = "Warrior";
		warrior.Actions = DefaultActions();
	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Slash", 1));
		defaultActions.Add (new TeamAttack ("Team attack" , 1));
		defaultActions.Add (new SingleAttack ("Stab", 1));
		defaultActions.Add (new SingleAttack ("Slice",1));
		return defaultActions;
	}
}
