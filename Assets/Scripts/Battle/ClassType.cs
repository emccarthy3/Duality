using UnityEngine;
using System.Collections;

//Classtype defines the type of the character (warrior, ranger, or magician)
public class ClassType {
	private string className;
	private Hashtable moves;


	public string ClassName{
		get{ return className; }
		set{ className = value; }
	}

}
