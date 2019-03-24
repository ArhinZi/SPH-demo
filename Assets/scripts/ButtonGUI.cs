using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGUI : MonoBehaviour
{


    //переменная для хранения обьекта main
    public main nMain;
    //текстуры курсоров
    public Texture2D SelectCursore_act;
    public Texture2D SelectCursore_nact;
    public Texture2D DelCursore_act;
    public Texture2D DelCursore_nact;
    public Texture2D DragCursore_act;
    public Texture2D DragCursore_nact;
    public Texture2D WallCursore;
    public Texture2D WaterCursore;
    //иконки кнопок
    public Texture2D B_Select;
    public Texture2D B_Del;
    public Texture2D B_Drag;
    public Texture2D B_Wall;
    public Texture2D B_Water;
    //стили
    public GUIStyle Button_style;
    public GUIStyle Panel_style;
    //переменные курсора
    public Texture2D Cursor_tex;
    Vector2 mouse;
    int wh = 0;

    public string lastTooltip = " ";



    // Use this for initialization
    void Start()
    {
        //инициализация
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
        Cursor_tex = SelectCursore_nact;
    }



    // Update is called once per frame
    void Update()
    {
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
    }





    void OnGUI()
    {
        //создание панели инструментов
        GUI.Box(new Rect(10, 10, 245, 40), new GUIContent("", "Tool_panel"), Panel_style);
        //Выбор
        if (GUI.Button(new Rect(15, 15, 30, 30), "", Button_style))
        {
            wh = 0;
            nMain.Tool_id = (int)main.Tool.select;
            Cursor_tex = SelectCursore_nact;
            nMain.Select_Cursor((int)main.Tool.select);
        }
        GUI.DrawTexture(new Rect(20, 20, 20, 20), B_Select);
        //Перемещение
        if (GUI.Button(new Rect(15 + 45 * 1, 15, 30, 30), "", Button_style))
        {
            wh = 25;
            nMain.Tool_id = (int)main.Tool.drag;
            Cursor_tex = DragCursore_nact;
            nMain.Select_Cursor((int)main.Tool.drag);
        }
        GUI.DrawTexture(new Rect(20 + 45 * 1, 20, 20, 20), B_Drag);
        //Удаление
        if (GUI.Button(new Rect(15 + 45 * 2, 15, 30, 30), "", Button_style))
        {
            wh = 0;
            nMain.Tool_id = (int)main.Tool.del;
            Cursor_tex = DelCursore_nact;
            nMain.Select_Cursor((int)main.Tool.del);
        }
        GUI.DrawTexture(new Rect(20 + 45 * 2, 20, 20, 20), B_Del);
        //Стена
        if (GUI.Button(new Rect(15 + 45 * 3, 15, 30, 30), "", Button_style))
        {
            wh = 25;
            nMain.Tool_id = (int)main.Tool.wall;
            Cursor_tex = WallCursore;
            nMain.Select_Cursor((int)main.Tool.wall);
        }
        GUI.DrawTexture(new Rect(20 + 45 * 3, 20, 20, 20), B_Wall);
        //Вода
        if (GUI.Button(new Rect(15 + 45 * 4, 15, 30, 30), "", Button_style))
        {
            wh = 25;
            nMain.Tool_id = (int)main.Tool.water;
            Cursor_tex = WaterCursore;
            nMain.Select_Cursor((int)main.Tool.water);
        }
        GUI.DrawTexture(new Rect(20 + 45 * 4, 20, 20, 20), B_Water);

        //создание событий наведения курсора на GUI
        if (Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip)
        {
            if (lastTooltip != "")
                SendMessage(lastTooltip + "OnMouseOut", SendMessageOptions.DontRequireReceiver);
            if (GUI.tooltip != "")
                SendMessage(GUI.tooltip + "OnMouseOver", SendMessageOptions.DontRequireReceiver);
            lastTooltip = GUI.tooltip;
        }

        //Курсор
        GUI.DrawTexture(new Rect(mouse.x - (wh / 2), mouse.y - (wh / 2), 25, 25), Cursor_tex);

    }





    void Tool_panelOnMouseOver()
    {
        nMain.loose = false;
    }
    void Tool_panelOnMouseOut()
    {
        nMain.loose = true;
    }
}
