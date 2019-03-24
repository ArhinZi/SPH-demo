using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscGUI : MonoBehaviour {

    int w = 100;
    int h = 200;

	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
		
	}





    void OnGUI()
    {
        //создание панели инструментов
        GUI.Box(new Rect(Screen.width/2 - w/2, Screen.height/2 - h/2, w, h), "Меню");
        if (GUI.Button(new Rect(Screen.width / 2 - w / 2 + 5, Screen.height / 2 - h / 2 + 25, w-10, 25), "Вернуться"))
        {
            GetComponent<myGUI>().Escape();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - w / 2 + 5, Screen.height / 2 - h / 2 + 50, w - 10, 25), "Выйти"))
        {
            Application.Quit();
        }
    }
}
