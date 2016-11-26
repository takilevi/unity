using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public Transform mainmenu, optionsmenu;
	public void LoadScene(string name){
		Application.LoadLevel (name);
	}
	public void QuitGame(){
		Application.Quit ();
	}
	public void OptionsMenu(bool clicked)
	{
		if (clicked) {
			optionsmenu.gameObject.SetActive(true);
			mainmenu.gameObject.SetActive(false);
		}
		if (!clicked) {
			optionsmenu.gameObject.SetActive(false);
			mainmenu.gameObject.SetActive(true);
		}
	}
}
