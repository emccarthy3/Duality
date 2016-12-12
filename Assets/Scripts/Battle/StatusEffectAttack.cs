using UnityEngine;
using System.Collections;

public class StatusEffectAttack : Action {

	private int baseDamage;
	private string name;
	private int effectDamage;

	public StatusEffectAttack(string name, int baseDamage) {
		Name = name;
		BaseDamage = baseDamage;
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
