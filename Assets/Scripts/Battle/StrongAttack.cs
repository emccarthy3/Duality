using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : Action {

	private int baseDamage;
	private string name;
	private int effectDamage;

	public StrongAttack(string name, int baseDamage) {
		Name = name;
		BaseDamage = baseDamage;
	}


	public override void ActionBehavior ()
	{
		BaseDamage = 3;
		float rand = Random.Range (0f, 1f);
		if (rand < .5) {
			BaseDamage = 0;
		}
	}
}
