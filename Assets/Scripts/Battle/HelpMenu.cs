using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpMenu : MonoBehaviour {
	[SerializeField] private Button weaponsTriangle;
	[SerializeField] private Button moves;
	[SerializeField] private Button back;
	[SerializeField] private Text descriptionText;
	// Use this for initialization
	void Start () {
		back.gameObject.SetActive (false);
		descriptionText.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}

	public void ChangeButtonVisibility(bool enable){
		weaponsTriangle.gameObject.SetActive (enable);
		moves.gameObject.SetActive (enable);
		back.gameObject.SetActive (!enable);
		descriptionText.gameObject.SetActive (!enable);
	}

	public void Back(){
		ChangeButtonVisibility (true);
	}

	public void ShowWeaponsTriangle(){
		ChangeButtonVisibility (false);
		descriptionText.text = "The Weapons triangle determines any bonus damage dealt to the opponent when attacking.  When the attacking class has an advantage " +
		"the attack will deal x 2 damage.  Warriors are strong against rangers, rangers are strong against magicians, and magicians are strong against warriors." +
		"If the attacking character attacks someone who has an advantage against them, they will only deal .5 x damage, so strategize accordingly!";
	}

	public void Moves(){
		ChangeButtonVisibility (false);
	}
}
