using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Battle {
	int turn = 0;

	private Character playerChar;
	private Character partnerChar;
	private Character enemy1;
	private Character enemy2;
	private Action selectedAction;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private static List<Character> battlers;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	private int attackerIndex = 0;
	private const int FINAL_PLAYER = 1;

	public Battle(){
		battlers = new List<Character> ();
		playerChar= new Player (1);
		partnerChar= new Ally(2);
		partnerChar.PersonalityType = 8;
		enemy1= new Enemy(3);
		enemy2 = new Enemy (1);
		battlers.Add (playerChar);
		battlers.Add (partnerChar);
		battlers.Add (enemy1);
		battlers.Add (enemy2);
		Debug.Log ("Battlers" + battlers [1]);
		ui.SetButtonListeners (playerChar);

	}
	// Method to trigger enemy attacks after both player characters attack.  will implement AI
	public void EnemyAttacks(){
		SelectedAction = enemy1.Actions[0];
		Fight (playerChar);
		//enemy2.Attack ();
		ui.EnableButtonsForPlayerAttack ();
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public IEnumerator Fight(Character defender){
		status.text = battlers[attackerIndex].Name + SelectedAction;
		DealDamage (defender);
		ui.UpdateHPLabels (defender.Name, battlers.IndexOf(defender), defender.HP);
		//SelectedAction.ActionBehavior ();
		yield return new WaitForSeconds (1);
		SwitchAttacker ();
		currentPlayer.text = battlers[attackerIndex].Name + "'s turn";
	}

	//property for setting/getting the move selected for the current turn
	public Action SelectedAction{
		get{return selectedAction;}
		set{ selectedAction = value; }
	}
	//will calculate damage dealt
	public void DealDamage(Character defender){
		defender.HP -= selectedAction.BaseDamage;
	}
	public Character Enemy1{
		get{ return enemy1; }
		set{ enemy1 = value; }
	}

	public Character Enemy2{
		get{ return enemy2; }
		set{ enemy2 = value; }
	}
	//allows for turn based attack system
	public void SwitchAttacker(){
		if (attackerIndex == FINAL_PLAYER) {
			ui.DisableButtonsForEnemyAttack ();
			EnemyAttacks ();
		}
		else{
			ui.SetButtonListeners (battlers [attackerIndex]);
	}
		attackerIndex++;
}
}
