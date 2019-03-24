using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class main : MonoBehaviour {
    //список инструментов
    public enum Tool { select, drag, del, wall, water};


	//свободно ли место для заполнения
    public bool loose;
	//айди текущего инструмента
    public int Tool_id;
	//префабы обьектов
    public GameObject Prefab_wall;
    public GameObject Prefab_water;




    // Use this for initialization
    void Start ()
    {
        //инициализация 
        Tool_id = (int)Tool.select;
        loose = true;
		//отключение системного курсора
        Cursor.visible = false;
        //выбор курсора при старте
        Select_Cursor(0);
    }
	


	// Update is called once per frame
	void Update () 
	{

    }





    /// <summary>
    /// Округление до кратного числа
    /// </summary>
    public float Round_crat(float val, float i)
    {
        if (val / i != 0)
            val = ((float)System.Math.Round(val / i)) * i;
        return val;
    }



    /// <summary>
    /// смена режима курсора
    /// </summary>
    public void Select_Cursor(int i)
    {
        GetComponent<Cursor_Select>().enabled = false;
        GetComponent<Cursor_Drag>().enabled =   false;
        GetComponent<Cursor_Del>().enabled =    false;
        GetComponent<Cursor_Wall>().enabled =   false;
        GetComponent<Cursor_Water>().enabled =  false;
        switch (i)
        {
            case (int)Tool.select:
                GetComponent<Cursor_Select>().enabled = true;
                break;
            case (int)Tool.drag:
                GetComponent<Cursor_Drag>().enabled = true;
                break;
            case (int)Tool.del:
                GetComponent<Cursor_Del>().enabled = true;
                break;
            case (int)Tool.wall:
                GetComponent<Cursor_Wall>().enabled = true;
                break;
            case (int)Tool.water:
                GetComponent<Cursor_Water>().enabled = true;
                break;
        }
    }



}
