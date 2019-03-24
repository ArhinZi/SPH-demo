using UnityEngine;
using System.Collections;

public class Cursor_Wall : MonoBehaviour {


    //переменная для хранения обьекта main
	public main nMain;
    //переменная для хранения обьекта gui
    public ButtonGUI nB_GUI;

    public Static_obj nSObj;
    //переменные инвокера
    public float invoke_start = 0;
    public float invoke_pause = 0.2f;



	// Use this for initialization
	void Start ()
    {
        //инициализация
		nMain = GameObject.FindObjectOfType(typeof(main)) as main;
        nB_GUI = GameObject.FindObjectOfType(typeof(ButtonGUI)) as ButtonGUI;
        nSObj = GameObject.FindObjectOfType(typeof(Static_obj)) as Static_obj;
    }
	


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Create_Wall", invoke_start, invoke_pause);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Create_Wall");
        }
    }





    void OnDisable()
    {
        CancelInvoke("Create_Wall");
    }



    /// <summary>
    /// Функция создания стены для InvokeRepeating
    /// </summary>
    void Create_Wall()
    {
        if (nMain.loose == true)
        {
            nSObj.walls_count++;
            nSObj.walls.Add(Instantiate(nMain.Prefab_wall));
            nSObj.walls[nSObj.walls_count - 1].name = "Wall" + (nSObj.walls_count);
            nSObj.walls[nSObj.walls_count - 1].transform.position = new Vector2
                (
                    nMain.Round_crat(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0.5f),
                    nMain.Round_crat(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.5f)
                );
            nSObj.walls[nSObj.walls_count - 1].transform.parent = nSObj.transform;
        }
    }



}
