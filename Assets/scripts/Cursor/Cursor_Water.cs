using UnityEngine;
using System.Collections;

public class Cursor_Water : MonoBehaviour {


    //переменная для хранения обьекта main
    public main nMain;
    //переменная для хранения обьекта B_GUI
    public ButtonGUI nB_GUI;

    public SPH nSPH;
    //переменные инвокера
    public float invoke_start = 0;
    public float invoke_pause = 0.5f;
    public int powerw = 1;
    public int powerh = 1;



    // Use this for initialization
    void Start ()
    {
        //инициализация
		nMain = GameObject.FindObjectOfType(typeof(main)) as main;
        nB_GUI = GameObject.FindObjectOfType(typeof(ButtonGUI)) as ButtonGUI;
        nSPH = GameObject.FindObjectOfType(typeof(SPH)) as SPH;
    }
	


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
		{
            InvokeRepeating("Create_Water", invoke_start, invoke_pause);
		}
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Create_Water");
        }
    }





    void OnDisable()
    {
        CancelInvoke("Create_Water");
    }



    /// <summary>
    /// Функция создания воды для InvokeRepeating
    /// </summary>
    void Create_Water()
    {
        if (nMain.loose == true)
        {
            float dist = 0.11f;
            float shift = 0.1f;
            int w = powerw;
            int h = powerh;
            float stw = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - (dist * w / 2);
            float sth = Camera.main.ScreenToWorldPoint(Input.mousePosition).y + (dist * h / 2);
            for (int i = 0; i< w ; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    nSPH.particles_count++;
                    nSPH.particles.Add(Instantiate(nMain.Prefab_water));
                    nSPH.particles[nSPH.particles_count - 1].name = "Water" + nSPH.particles_count;
                    nSPH.particles[nSPH.particles_count - 1].GetComponent<Fluid_particle>().part_id = nSPH.particles_count;
                    nSPH.particles[nSPH.particles_count - 1].transform.position = new Vector2
                        (
                            stw + i * dist + j * shift,
                            sth + j * dist
                        );
                    nSPH.particles[nSPH.particles_count - 1].transform.parent = nSPH.transform;
                }
            }
            
        }
    }



}