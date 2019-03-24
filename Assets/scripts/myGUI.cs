using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGUI : MonoBehaviour {


    public bool pause = false;
    public bool EsC = false;
	// Use this for initialization
	void Start () {
        GetComponent<ButtonGUI>().enabled = true;
        GetComponent<EscGUI>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        //пауза
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause = true;
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
            }
        }
        //пауза/меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }  
    }




    public void Escape()
    {
            if (EsC == false)
            {
                EsC = true;
                if (pause == false)
                {
                    Time.timeScale = 0;
                }
                Cursor.visible = true;
                GetComponent<ButtonGUI>().enabled = false;
                GetComponent<EscGUI>().enabled = true;
            }
            else
            {
                EsC = false;
                if (pause == false)
                {
                    Time.timeScale = 1;
                }
                Cursor.visible = false;
                GetComponent<ButtonGUI>().enabled = true;
                GetComponent<EscGUI>().enabled = false;
            }
    }
}
