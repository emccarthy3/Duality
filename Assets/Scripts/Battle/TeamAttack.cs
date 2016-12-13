using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeamAttack : Action {
	private int baseDamage;
	private string name;

	public TeamAttack(string name, int baseDamage,ParticleSystem particleSystem) : base(name,  baseDamage,  particleSystem){
	}
		
	public override void ActionBehavior (){
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
