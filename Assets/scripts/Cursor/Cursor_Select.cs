using UnityEngine;
using System.Collections;

public class Cursor_Select : MonoBehaviour {


    //переменная для хранения обьекта gui
    public ButtonGUI nB_GUI;



    // Use this for initialization
    void Start()
    {
        //инициализация
        nB_GUI = GameObject.FindObjectOfType(typeof(ButtonGUI)) as ButtonGUI;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nB_GUI.Cursor_tex = nB_GUI.SelectCursore_act;
        }
        if (Input.GetMouseButtonUp(0))
        {
            nB_GUI.Cursor_tex = nB_GUI.SelectCursore_nact;
        }
    }





}
