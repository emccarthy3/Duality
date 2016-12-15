using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHealState : HealState {
	private Battle battle;
	private UIController ui;
	private Character battler;

	public NoHealState(UIController ui, Battle battle ,Character battler): base(ui, battle, battler){
		this.battle = battle;
		this.ui = ui;
		this.battler = battler;
	}

	public override void Heal(int maxHP, int healAmount){
		battle.StartCoroutine(ui.UpdateHealStatus (battler.Name, 0, false, battler.HealCount));
	}
}
