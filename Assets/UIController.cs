﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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


	// Use this for initialization
	void Start () {
	
	enemyChooser.Close ();
	moveChooser.Open ();

		enemy1Button.onClick.AddListener(() =>  OnEnemySelect("Enemy1"));
		enemy2Button.onClick.AddListener(() =>  OnEnemySelect("Enemy2"));
		playerHP.text = "Player HP: " + 10;
		partnerHP.text = "Partner HP: " + 10;
		enemy1HP.text = "Enemy 1 HP: " + 10;
		enemy2HP.text = "Enemy 2 HP: " + 10;
	//	partnerAttack.gameObject.SetActive (false);
	//	block.gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
	}
	public void Close(){
		
	}
	public void OnAttackSelect(Moves move){
		enemyChooser.Open ();
	}
	public void UpdateHPLabels(string name,int index,int hp){
		hpList [index].text = name + " HP: " + hp;
		
	}
	public void OnEnemySelect(string enemyName){
		

	//	battle.BattleLoop ();
		StartCoroutine(battle.Fight("Attacking"));

		//battle.BattleLoop ();

		enemyChooser.Close ();
	}
	public void DisableButtonsForEnemyAttack(){
		foreach(Button button in moveButtons){
			button.gameObject.SetActive (false);
		}
	}
	public void EnableButtonsForPlayerAttack(){
		//block.gameObject.SetActive (true);	
		//heal.gameObject.SetActive (true);
		//singleAttack.gameObject.SetActive (true);
		//partnerAttack.gameObject.SetActive (true);
	}
	public void SetButtonListeners(Character battler){
		for (int i = 0; i < moveButtons.Count; i++) {
			moveButtons [i].onClick.AddListener (() => {
			//	battler.Moves [i].MoveBehavior (); 
				battle.SelectedMove = battler.Moves[i];
				OnAttackSelect(battler.Moves[i]);
			//	OnAttackSelect(new SingleAttack());
			});
		}
	}
}
