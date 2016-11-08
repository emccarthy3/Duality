using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Battle : MonoBehaviour {
	int turn = 0;

	private Character playerChar;
	private Character partnerChar;
	private Character enemy1;
	private Character enemy2;
	private Moves selectedMove;
	[SerializeField] private Text status;
	[SerializeField] private Text currentPlayer;
	[SerializeField] private UIController ui;
	private List<Character> battlers;
	private List<int> enemyRandomAttacks;
	private Character attacker;
	private Character defender;


	//adds all battlers to a list in order to allow a loop through for turn based RPG
	void Start () {		
		//get these characters from the first scene
		playerChar= new Player ();
		partnerChar= new Ally();
		enemy1= new Enemy();
		enemy2 = new Enemy ();
		ui.SetButtonListeners (playerChar);
	}

	// Method to trigger enemy attacks after both player characters attack
	public void EnemyAttacks(){
		enemy1.Attack ();
		enemy2.Attack ();
		ui.EnableButtonsForPlayerAttack ();
	}

	// Performs fighting moves (will use animation) when chosen.  Puts a delay between action selected and the move performing for a more natural feel
	public IEnumerator Fight(string action){
		status.text = action + SelectedMove;
		SelectedMove.MoveBehavior ();
		yield return new WaitForSeconds (1);
		currentPlayer.text = attacker+ "'s turn";
	}

	//property for setting/getting the move selected for the current turn
	public Moves SelectedMove{
		get{return selectedMove;}
		set{ selectedMove = value; }
	}
}
