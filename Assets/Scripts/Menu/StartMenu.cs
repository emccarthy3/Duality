using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	[SerializeField] private Button startButton;
	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(() =>  SwitchScenes());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void SwitchScenes(){
		SceneManager.LoadScene ("Story");
	}

}
