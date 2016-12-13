using UnityEngine;
using System.Collections;

public class StatusEffectAttack : Action {

	public StatusEffectAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}


	public override void ActionBehavior ()
	{
		BaseDamage = 1;
		EffectDamage = 1;
		float rand = Random.Range (0f, 1f);
		if (rand < .7) {
			BaseDamage = 0;
			EffectDamage = 0;
		}
	}
}
