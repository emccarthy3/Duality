using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : Action {

	public StrongAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
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
