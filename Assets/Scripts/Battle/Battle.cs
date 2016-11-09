using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//Class for  controlling the battle.  Written by: Betsey
public class Battle : MonoBehaviour{
	private Player playerChar;
	private Ally partnerChar;
	private Enemy enemy1;
	private Enemy enemy2;
	private Action selectedAction;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private List<Character> battlers;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;
	private const int FINAL_PLAYER = 1;

	//initializes battle.  Having issues with turn based combat.  Want to use a List of battlers but getting null when casting players to Character
	void Start(){
		playerChar= new Player (1);
		partnerChar= new Ally(2);
		partnerChar.PersonalityType = 8;
		enemy1= new Enemy(3);
		enemy2 = new Enemy (1);
		ui.SetButtonListeners (playerChar);
		attacker = playerChar;
		Debug.Log ("attacker" + attacker);
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
		status.text = attacker +  "" + SelectedAction;
		DealDamage (defender);
		ui.UpdateHPLabels (defender.Name, 2, defender.HP);
		selectedAction.ActionBehavior ();
		yield return new WaitForSeconds (1);
		SwitchAttacker ();
		currentPlayer.text = attacker + "'s turn";
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

	//property for setting enemies for player attacks
	public Enemy  Enemy1{
		get{ return enemy1; }
		set{ enemy1 = value; }
	}

	//property for setting enemies for player attacks
	public Enemy Enemy2{
		get{ return enemy2; }
		set{ enemy2 = value; }
	}
	//allows for turn based attack system. Want this to go through a loop of battlers
	public void SwitchAttacker(){
	//	attacker = playerChar.NextPlayer;
	
	//	Debug.Log ("New Attacker! " + attacker.Name);
		/*if (attackerIndex == FINAL_PLAYER) {
			ui.DisableButtonsForEnemyAttack ();
			EnemyAttacks ();
		}
		else{
			ui.SetButtonListeners (battlers [attackerIndex]);
	}
		attackerIndex++;
		*/

}
}
