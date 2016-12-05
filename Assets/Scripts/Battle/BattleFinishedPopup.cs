using UnityEngine;
using System.Collections;

public class BattleFinishedPopup : MonoBehaviour {
	[SerializeField] private GameObject button;
	// Use this for initialization
	void Start () {

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
}
