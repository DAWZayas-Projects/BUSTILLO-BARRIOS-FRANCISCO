using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

	public void DeleteData(){
		PlayerPrefs.DeleteKey("TopScore");
		PlayerPrefs.DeleteKey("Avatar");
	}
	
}
