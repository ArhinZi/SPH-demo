using UnityEngine;
using System.Collections;

public class Upd_loose : MonoBehaviour {


    //переменная для хранения обьекта main
    public main nMain;



    // Use this for initialization
    void Start()
    {
        //инициализация
        nMain = GameObject.FindObjectOfType(typeof(main)) as main;
    }



    // Update is called once per frame
    void Update()
    {

    }





    void OnMouseEnter()
    {
        nMain.loose = false;
    }
    void OnMouseExit()
    {
        nMain.loose = true;
    }
}
