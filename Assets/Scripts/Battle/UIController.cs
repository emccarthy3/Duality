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
	[SerializeField] private EnemyChooser enemyChooser;
	[SerializeField] private MoveChooser moveChooser;
	[SerializeField] private Battle battle;
	[SerializeField] private Button enemy1Button;
	[SerializeField] private Button enemy2Button;
	[SerializeField] private List<Button> moveButtons;
	[SerializeField] private Text playerHP;
	[SerializeField] private Text partnerHP;
	[SerializeField] private Text enemy1HP;
	[SerializeField] private Text enemy2HP;
	[SerializeField] private List<Text> hpList;
	private Player player;


	// Initializes UI for battle, starts with a UI for the character to choose their first move.
	void Start () {
		enemyChooser.Close ();
		moveChooser.Open ();
		enemy1Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy1));
		enemy2Button.onClick.AddListener(() =>  OnEnemySelect(battle.Enemy2));
		playerHP.text = "Player HP: " + 10;
		partnerHP.text = "Partner HP: " + 10;
		enemy1HP.text = "Enemy 1 HP: " + 10;
		enemy2HP.text = "Enemy 2 HP: " + 10;
	}

	//when a move is chosen by the player, another window will be displayed to show which enemy to use the attack on
	public void OnAttackSelect(Action action){
		Debug.Log (action.Name + "Action name");
		enemyChooser.Open ();
	}

	//this method updates the HP levels once a value has changed either from an attack or heal move.
	public void UpdateHPLabels(string name,int index,double hp){
		hpList [index].text = name + " HP: " + hp;
		
	}

	//once the enemy to attack is chosen through the enemy chooser display, the attack move will be carried out.
	public void OnEnemySelect(Character enemy){
		StartCoroutine(battle.Fight(enemy));
		enemyChooser.Close ();
	}

	//this method makes the character move buttons temporarily disabled so the player cannot move while the enemy is moving.
	public void DisableButtonsForEnemyAttack(){
		foreach(Button button in moveButtons){
			button.gameObject.SetActive (false);
		}
	}

	//this method displays the buttons which were hidden during the enemy attacks
	public void EnableButtonsForPlayerAttack(){
		//block.gameObject.SetActive (true);	
		//heal.gameObject.SetActive (true);
		//singleAttack.gameObject.SetActive (true);
		//partnerAttack.gameObject.SetActive (true);
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
			moveButtons [i].GetComponentInChildren<Text> ().text = battler.Actions[i].Name;
			//moveButtons[i].onClick.AddListener(() => { battle.SelectedAction = battler.Actions[i];
			//	OnAttackSelect(battler.Actions[i]);});
			i++;
		}
			
		moveButtons [0].onClick.AddListener (() => {
			battle.SelectedAction = battler.Actions [0];
			OnAttackSelect (battler.Actions [0]);
		});
		moveButtons [1].onClick.AddListener (() => {
			battle.SelectedAction = battler.Actions [1];
			OnAttackSelect (battler.Actions [1]);
		});
		moveButtons [2].onClick.AddListener (() => {
			battle.SelectedAction = battler.Actions [2];
			OnAttackSelect (battler.Actions [2]);
		});
		moveButtons [3].onClick.AddListener (() => {
			battle.SelectedAction = battler.Actions [3];
			OnAttackSelect (battler.Actions [3]);
		});
	}

}
