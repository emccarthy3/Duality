using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Magician : ClassType {
	private GameObject gc;
	private GameController gameController;

	public Magician(){
		ClassName = "Magician";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions();
	}


	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack("Fire bolt", 1,gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Earthquake",3, gameController.AttackSpecialEffects[1]));
		defaultActions.Add (new StatusEffectAttack ("Water wave", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new VulnerabilityAttack ("Mind boggle",0, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", .5);
		ClassEffectiveness.Add ("Magician", 1);
		ClassEffectiveness.Add ("Warrior", 2);
	}
}
