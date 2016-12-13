using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//defines warrior class
public class Warrior : ClassType {
	private GameObject gc;
	private GameController gameController;
	public Warrior(){
		ClassName = "Warrior";
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		Actions = DefaultActions();
	}

	public List<Action> DefaultActions(){
		List<Action> defaultActions = new List<Action>();
		defaultActions.Add (new SingleAttack ("Slash", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StrongAttack ("Impale",3, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new StatusEffectAttack ("Stab", 1, gameController.AttackSpecialEffects[0]));
		defaultActions.Add (new VulnerabilityAttack ("Intimidate",0, gameController.AttackSpecialEffects[0]));
		return defaultActions;
	}

	public override void InitializeClassBonusDamage(){
		ClassEffectiveness.Add ("Ranger", 2);
		ClassEffectiveness.Add ("Magician", .5);
		ClassEffectiveness.Add ("Warrior", 1);
	}

}
