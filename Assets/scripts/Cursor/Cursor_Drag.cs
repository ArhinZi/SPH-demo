using UnityEngine;
using System.Collections;

public class Cursor_Drag : MonoBehaviour {


    //переменная для хранения обьекта gui
    public ButtonGUI nB_GUI;
    public cam nCam;
    //переменная для хранения обьекта main
    public main nMain;



    // Use this for initialization
    void Start()
    {
        //инициализация
        nB_GUI = GameObject.FindObjectOfType(typeof(ButtonGUI)) as ButtonGUI;
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            nB_GUI.Cursor_tex = nB_GUI.DragCursore_act;
        }
        if (Input.GetMouseButtonUp(0))
        {
            nB_GUI.Cursor_tex = nB_GUI.DragCursore_nact;
        }
    }





}
