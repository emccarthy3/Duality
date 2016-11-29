using UnityEngine;
using System.Collections.Generic;

//Classtype defines the type of the character (warrior, ranger, or magician)
public abstract class ClassType {
	private string className;
	private Dictionary<string,double> classEffectiveness;

	public ClassType(){
		classEffectiveness = new Dictionary<string, double> ();
		InitializeClassBonusDamage ();
	}
	public string ClassName{
		get{ return className; }
		set{ className = value; }
	}

	public Dictionary<string,double> ClassEffectiveness{
		get{ return classEffectiveness; }
		set{ classEffectiveness = value; }
	}

	public abstract void InitializeClassBonusDamage();
}

