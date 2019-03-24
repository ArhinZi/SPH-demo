using UnityEngine;
using System.Collections;

public class Cursor_Del : MonoBehaviour {


    //переменная для хранения обьекта gui
    public ButtonGUI nB_GUI;
    public cam nCam;


    // Use this for initialization
    void Start ()
    {
        //инициализация
        nB_GUI = GameObject.FindObjectOfType(typeof(ButtonGUI)) as ButtonGUI;
        nCam = GameObject.FindObjectOfType(typeof(cam)) as cam;
    }
	


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
		{
            nB_GUI.Cursor_tex = nB_GUI.DelCursore_act;
            GameObject i = nCam.GetObj();
            if (i != null && (i.tag == "Wall" || i.tag == "Water"))
            {
                Destroy(i);
            }  
		}
        if (Input.GetMouseButtonUp(0))
		{
            nB_GUI.Cursor_tex = nB_GUI.DelCursore_nact;
        }
    }





}
