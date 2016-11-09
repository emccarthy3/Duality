using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Magician : ClassType {


	public Magician(Character magician){
		ClassName = "Magician";
		magician.Actions = DefaultActions();
	}
		
		
	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Fire bolt", 1));
		defaultActions.Add (new TeamAttack ("Team attack" , 1));
		defaultActions.Add (new SingleAttack ("Earthquake", 1));
		defaultActions.Add (new SingleAttack ("Water wave",1));
		return defaultActions;
	}

}
