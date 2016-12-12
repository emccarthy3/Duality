﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/* UIController class 
 * Controls the display for the battle 
 * Written by: Betsey McCarthy
 *
 */

public class UIController : MonoBehaviour {
	private GameObject gc;
	private GameController gameController;
	[SerializeField] private EnemyChooser enemyChooser;
	[SerializeField] private Popup moveChooser;
	[SerializeField] private Popup attackChooser;
	[SerializeField] private TeamAttackChooser teamAttackChooser;
	[SerializeField] private RestartPopup restartPopup;
	[SerializeField] private BattleFinishedPopup battleFinishedPopup;
	[SerializeField] private HelpMenu helpMenu;
	[SerializeField] private Battle battle;
	[SerializeField] private Button enemy1Button;
	[SerializeField] private Button enemy2Button;
	[SerializeField] private Button teamEnemy1Button;
	[SerializeField] private Button teamEnemy2Button;
	[SerializeField] private Button battleFinishedButton;
	[SerializeField] private Button singleAttackButton;
	[SerializeField] private Button teamAttackButton;
	[SerializeField] private Button exitHelpButton;
	[SerializeField] private Button restartButton;
	[SerializeField] private Button toMainMenuButton;
	[SerializeField] private Button helpButton;
	[SerializeField] private Text playerType;
	[SerializeField] private Text partnerType;
	[SerializeField] private Text enemy1Type;
	[SerializeField] private Text enemy2Type;
	[SerializeField] private List<Button> moveButtons;
	[SerializeField] private Text playerHP;
	[SerializeField] private Text partnerHP;
	[SerializeField] private Text enemy1HP;
	[SerializeField] private Text enemy2HP;
	[SerializeField] private Text damageDealt;
	[SerializeField] private List<Text> hpList;
	[SerializeField] private Text moveStatusText;

	private Character enemy;
	private List<Text> typeLabels;
	private Player player;


	// Initializes UI for battle, starts with a UI for the character to choose their first move.
	void Start () {
		typeLabels = new List<Text> ();
		typeLabels.Add (playerType);
		typeLabels.Add (partnerType);
		typeLabels.Add (enemy1Type);
		typeLabels.Add (enemy2Type);
		SetTypeLabels ();
		enemy = new Character ();
		gc = GameObject.Find ("GameController");
		gameController= gc.GetComponent <GameController> ();
		GameObject playerSprite = GameObject.Find ("PlayerSprite");
		playerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPlayer.PlayerSprite;
		GameObject partnerSprite = GameObject.Find ("PartnerSprite");
		partnerSprite.GetComponent<SpriteRenderer> ().sprite = gameController.YourPartner.PlayerSprite;
		enemyChooser.Close ();
		teamAttackChooser.Close ();
		attackChooser.Close ();
		battleFinishedPopup.Close ();
		restartPopup.Close ();
		helpMenu.Close ();
		moveChooser.Open ();
		enemy1Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy1));
		enemy2Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy2));
		teamEnemy1Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy1));
		teamEnemy2Button.onClick.AddListener(() =>  OnTeamAttackSelect(battle.Enemy2));
		teamAttackButton.onClick.AddListener(() =>  {battle.SelectedAction = new TeamAttack();
			OnAttackSelect (new TeamAttack());});
		singleAttackButton.onClick.AddListener (() => {
			moveChooser.Close ();
			attackChooser.Open ();
		});
		helpButton.onClick.AddListener(() =>  { helpMenu.Open(); attackChooser.Close(); ChangeButtonVisibility(false);});
		exitHelpButton.onClick.AddListener(() => { helpMenu.Close(); ChangeButtonVisibility(true);});
		restartButton.onClick.AddListener(() => { SceneManager.LoadScene("newBattle");});
		toMainMenuButton.onClick.AddListener(() => { SceneManager.LoadScene("StartScene");});
		battleFinishedButton.onClick.AddListener(() =>  ToNextScene());
		playerHP.text = "Player HP: " + gameController.YourPlayer.HP;
		partnerHP.text = "Partner HP: " + gameController.YourPartner.HP;
		enemy1HP.text = "Enemy 1 HP: " + battle.Enemy1.HP;
		enemy2HP.text = "Enemy 2 HP: " + battle.Enemy2.HP;
	}

	//when a move is chosen by the player, another window will be displayed to show which enemy to use the attack on
	public void OnAttackSelect(Action action){
		attackChooser.Close ();
		moveChooser.Close ();
		if (action.GetType ().Name == "TeamAttack") {
			teamAttackChooser.Open ();
		} else {
			enemyChooser.Open ();
		}
	}

	//this method updates the HP levels once a value has changed either from an attack or heal move.
	public void UpdateHPLabels(string name,int index,double hp){
		hpList [index].text = name + " HP: " + hp;

	}
	public void UpdateDamageDealt(string attackerName, string defenderName, double damage){
		damageDealt.text = attackerName + " dealt " + damage + " damage to " + defenderName;
	}
	public void SetTypeLabels(){
		for (int i = 0; i < battle.Battlers.Count; i++) {
			typeLabels [i].text = battle.Battlers [i].Type.ClassName;
		}
	}
	//once the enemy to attack is chosen through the enemy chooser display, the attack move will be carried out.
	public void OnEnemySelect(Character enemy){
		battle.Fight(enemy);
		enemyChooser.Close ();
	}
	public void ToNextScene(){
		gameController.BattleLoop += 1;
		if (gameController.BattleLoop == 3) {
			gameController.BattleLoop = 0;
			gameController.SwitchScene ("StartScene");
		} else {
			gameController.SwitchScene ("Dialogue1");
		}
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

	//rhthym controller calls this method once the team attack is finished and sends the final score to the UIController to send to the battle.
	public void teamAttackisFinished(int score){
		battle.DoTeamAttack (score);
	}

	public void UpdateHealStatus(string healerName, int HPRecovered, bool successfulHeal){
		if (successfulHeal) {
			damageDealt.text = healerName + " recovered " + HPRecovered + " hp ";
		} else {
			moveStatusText.text = "HP is already full! Pick a different move";
		}
	}
	public void UpdateBlockStatus(string blockerName){
		damageDealt.text = blockerName + " is blocking! ";

	}
	//opens popups for when the battle ends, either by the enemies being defeated or the player being defeated (determined by didDefeatEnemies)
	public void OnBattleEndDialogue(bool didDefeatEnemies){
		gameController.YourPlayer.HP = 10 + gameController.BattleLoop * 2;
		gameController.YourPartner.HP = 10 + gameController.BattleLoop * 2;;
		if (didDefeatEnemies) {
			battleFinishedPopup.Open ();
		} else {
			restartPopup.Open ();
		}
	}
	//this method makes the character move buttons temporarily disabled so the player cannot move while the enemy is moving.
	public void ChangeButtonVisibility(bool isPlayerTurn){
		if (!isPlayerTurn) {
			attackChooser.Close ();
			moveChooser.Close ();
		} else {
			attackChooser.Open ();
			moveChooser.Open ();
		}
	}

	//sets listeners for move buttons to perform move assigned to them according to the list of moves the character currently has. 
	public void SetButtonListeners(Character battler){
		if (battler.GetType().Name != "Enemy") {
			moveChooser.Open ();
		}
		moveStatusText.text = "Choose an action";
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

	//when a battler is defeated, this method is called to ensure the UI does not update defeated player HP labels.  Replaces HP with "defeated"
	public void RemoveFromHPList(int index){
		hpList [index].text = "Defeated!";
		hpList.RemoveAt (index);

	}


	public void ChangeCanvasState(bool state){
		GameObject c = GameObject.Find ("Canvas");
		Canvas canvas = c.GetComponent <Canvas> ();
		canvas.enabled = state;

	}

	//if an enemy is defeated, prevent the user from selecting them when attacking
	public void RemoveDefeatedEnemyButton(string enemyName){
		if (enemyName == "Enemy 1") {
			enemy1Button.gameObject.SetActive (false);
			teamEnemy1Button.gameObject.SetActive (false);
		} else {
			enemy2Button.gameObject.SetActive (false);
			teamEnemy2Button.gameObject.SetActive (false);
		}
	}
}

