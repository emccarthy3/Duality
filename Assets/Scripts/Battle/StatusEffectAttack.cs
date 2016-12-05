using UnityEngine;
using System.Collections;

public class StatusEffectAttack : Action {

	private int baseDamage;
	private string name;
	private int effectDamage;
	public StatusEffectAttack(string name, int baseDamage, int effectDamage) {
		Name = name;
		BaseDamage = baseDamage;
		this.effectDamage = effectDamage;
	}


	public override void ActionBehavior ()
	{
		Debug.Log ("we in");
		float rand = Random.Range (0f, 1f);
		if (rand < .33) {
			baseDamage += effectDamage;
		}
	}
}
