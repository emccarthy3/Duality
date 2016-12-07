using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/* UIController class 
 * Controls the display for the battle 
 * Written by: Betsey McCarthy
 *
 */

public class UIController : MonoBehaviour {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private EnemyChooser enemyChooser;
	[SerializeField] private MoveChooser moveChooser;
	[SerializeField] private TeamAttackChooser teamAttackChooser;
	[SerializeField] private BattleFinishedPopup battleFinishedPopup;
	[SerializeField] private HelpMenu helpMenu;
	[SerializeField] private Battle battle;
	[SerializeField] private Button enemy1Button;
	[SerializeField] private Button enemy2Button;
	[SerializeField] private Button teamEnemy1Button;
	[SerializeField] private Button teamEnemy2Button;
	[SerializeField] private Button battleFinishedButton;
	[SerializeField] private Button exitHelpButton;
	[SerializeField] private Button helpButton;
	[SerializeField] private List<Button> moveButtons;
	[SerializeField] private Text playerHP;
	[SerializeField] private Text partnerHP;
	[SerializeField] private Text enemy1HP;
	[SerializeField] private Text enemy2HP;
	[SerializeField] private List<Text> hpList;
	private Character enemy;

	private Player player;


	// Initializes UI for battle, starts with a UI for the character to choose their first move.
	void Start () {
		enemy = new Character ();
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		enemyChooser.Close ();
		teamAttackChooser.Close ();
		battleFinishedPopup.Close ();
		helpMenu.Close ();
		moveChooser.Open ();
		enemy1Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy1));
		enemy2Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy2));
		teamEnemy1Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy1));
		teamEnemy2Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy2));
		helpButton.onClick.AddListener(() =>  { helpMenu.Open(); ChangeButtonVisibility(false);});
		exitHelpButton.onClick.AddListener(() => { helpMenu.Close(); ChangeButtonVisibility(true);});
		battleFinishedButton.onClick.AddListener(() =>  gameController.SwitchScene("Dialogue1"));
		playerHP.text = "Player HP: " + gameController.YourPlayer.HP;
		partnerHP.text = "Partner HP: " + gameController.YourPartner.HP;
		enemy1HP.text = "Enemy 1 HP: " + battle.Enemy1.HP;
		enemy2HP.text = "Enemy 2 HP: " + battle.Enemy2.HP;
	}

	//when a move is chosen by the player, another window will be displayed to show which enemy to use the attack on
	public void OnAttackSelect(Action action){
		if (action.GetType().Name == "SingleAttack") {
			enemyChooser.Open ();
		}
		else if (action.GetType().Name == "TeamAttack") {
			teamAttackChooser.Open ();
		}
	}

	//this method updates the HP levels once a value has changed either from an attack or heal move.
	public void UpdateHPLabels(string name,int index,double hp){
		hpList [index].text = name + " HP: " + hp;

	}

	//once the enemy to attack is chosen through the enemy chooser display, the attack move will be carried out.
	public void OnEnemySelect(Character enemy){
		battle.Fight(enemy);
		enemyChooser.Close ();
	}

	//when a team attack is selected, a UI will appear to do the rhthym minigame
	public void OnTeamAttackSelect(Character enemy){
		battle.Defender = enemy;
		GameObject rc = GameObject.Find ("RhythmController");
		RhythmController rhythmController = rc.GetComponent <RhythmController> ();
		teamAttackChooser.Close ();
		ChangeCanvasState (false);
		rhythmController.Work();
	}

	public void teamAttackisFinished(int score){
		battle.DoTeamAttack (score);
	}

	public void OnBattleEndDialogue(){
		battleFinishedPopup.Open ();
	}
	//this method makes the character move buttons temporarily disabled so the player cannot move while the enemy is moving.
	public void ChangeButtonVisibility(bool isPlayerTurn){
		foreach(Button button in moveButtons){
			button.gameObject.SetActive (isPlayerTurn);
		}
	}

	//sets listeners for move buttons to perform move assigned to them according to the list of moves the character currently has. 
	public void SetButtonListeners(Character battler){
		//loop gives index out of bound error?
		//Debug.Log (moveButtons.Count + "Move buttons count");
		//Debug.Log (battler.Actions.Count + "Battler count");
		//Debug.Log(moveButtons.Count + "Move buttons count");
		int i = 0;
		foreach (Button button in moveButtons) { 
			//Debug.Log ("i is " + i);
			//for (int i = 0; i < moveButtons.Count; i++) {
			/*button.onClick.AddListener (() => {
				battle.SelectedAction = battler.Actions [i];
				OnAttackSelect (battler.Actions [i]);
			});
			*/
			moveButtons [i].GetComponentInChildren<Text> ().text = battler.Type.Actions[i].Name;
			//moveButtons[i].onClick.AddListener(() => { battle.SelectedAction = battler.Actions[i];
			//	OnAttackSelect(battler.Actions[i]);});
			i++;
		}

		moveButtons [0].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [0];
			OnAttackSelect (battler.Type.Actions [0]);
		});
		moveButtons [1].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [1];
			OnAttackSelect (battler.Type.Actions [1]);
		});
		moveButtons [2].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [2];
			OnAttackSelect (battler.Type.Actions [2]);
		});
		moveButtons [3].onClick.AddListener (() => {
			battle.SelectedAction = battler.Type.Actions [3];
			OnAttackSelect (battler.Type.Actions [3]);
		});
	}
	public void RemoveFromHPList(int index){
		hpList [index].text = "Defeated!";
		hpList.RemoveAt (index);
	}

	public void ChangeCanvasState(bool state){
		GameObject c = GameObject.Find ("Canvas");
		Canvas canvas = c.GetComponent <Canvas> ();
		canvas.enabled = state;


	}

}

