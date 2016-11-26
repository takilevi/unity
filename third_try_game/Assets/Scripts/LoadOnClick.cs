using UnityEngine;
using System.Collections;
using System;

public class LoadOnClick : MonoBehaviour {

    public GameObject LoadingImage;

	public void LoadScene(int level)
    {
        if (level == -1)
        {
            System.Random rand = new System.Random(DateTime.Now.Millisecond);
            Application.LoadLevel(rand.Next(1, 4));
        }
        if(level == -2)
        {
            print("Exit");
            Application.Quit();
        }
        else {
            LoadingImage.SetActive(true);
            Application.LoadLevel(level);
        }
    }

}
