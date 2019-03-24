using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {


    //переменная для хранения обьекта main
    public main nMain;



	// Use this for initialization
	void Start ()
    {
        //инициализация
		nMain = GameObject.FindObjectOfType(typeof(main)) as main;
	}



    // Update is called once per frame
    void Update ()
    {
	
	}





    void OnMouseDrag()
    {
        if (tag == "Wall" && nMain.Tool_id == (int)main.Tool.drag)
        {
            transform.position = new Vector3
                (
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).z + 10
                );
        }
        else if (tag == "Water" && nMain.Tool_id == (int)main.Tool.drag)
        {
            GetComponent<Rigidbody2D>().MovePosition(new Vector2
                (
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y
                ));
        }
        
    }



    void OnMouseUp()
    {
        if (tag == "Wall" && nMain.Tool_id == (int)main.Tool.drag)
        {
            transform.position = new Vector2
                (
                    nMain.Round_crat(transform.position.x, 0.5f),
                    nMain.Round_crat(transform.position.y, 0.5f)
                    );
        }
    }
}
