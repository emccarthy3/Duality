using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ranger : ClassType {
	private GameObject gc;
	private GameController gameController;
	public Ranger(){
		ClassName = "Ranger";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions();
	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Shoot Arrow", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Chuck Rock",3, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StatusEffectAttack ("Sharpshoot", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new VulnerabilityAttack ("Taunt",0, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 1);
		ClassEffectiveness.Add ("Magician", 2);
		ClassEffectiveness.Add ("Warrior", .5);
	}
}
