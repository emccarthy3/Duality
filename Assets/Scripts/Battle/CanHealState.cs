using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanHealState : HealState {
	private UIController ui;
	private Battle battle;
	private Character battler;

	public CanHealState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		this.ui = ui;
		this.battle = battle;
		this.battler = battler;
	}

	public override void Heal(int maxHP,int healAmount){
		if (battler.HP <= maxHP - healAmount) {
			battler.HP += healAmount;
		} else {
			battler.HP = maxHP;
		}
		battler.HealCount--;
		ui.ChangeButtonVisibility (false);
		battle.StartCoroutine(ui.UpdateHealStatus (battler.Name, healAmount, true, battler.HealCount));
		battle.StartCoroutine(ui.UpdateHPLabels (battler.Name, battle.Battlers.IndexOf (battler), battler.HP, false,0));

	}
}
