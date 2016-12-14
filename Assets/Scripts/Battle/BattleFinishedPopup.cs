using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleFinishedPopup : MonoBehaviour {
	[SerializeField] private Text text;
	[SerializeField] private Text buttonText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetStatusText(string text, string buttonText){
		this.text.text = text;
		this.buttonText.text = buttonText;
	}
	public void Open(){
		gameObject.SetActive (true);

	}

	public void Close(){
		gameObject.SetActive (false);
	}
}
