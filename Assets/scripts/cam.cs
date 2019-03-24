using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {


    //временные переменные
   // float x_temp;
   // float y_temp;
    //минимум и максимум зума
    public float max_size = 3.8f;
    public float min_size = 1.5f;



    // Use this for initialization
    void Start ()
    {
       // x_temp = Camera.main.transform.position.x - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
       // y_temp = Camera.main.transform.position.y - Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, 0, 0)).y;
    }
	


	// Update is called once per frame
	void Update ()
    {
        Debug.Log(GetObj().name);
        //зум камеры(ближе-дальше)
        /* if (Input.GetAxis("Mouse ScrollWheel") < 0)
         {
             Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= 0.2f, min_size, max_size);
             x_temp = Camera.main.transform.position.x - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
             y_temp = Camera.main.transform.position.y - Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, 0, 0)).y;
         }
         else if (Input.GetAxis("Mouse ScrollWheel") > 0)
         {
             Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize += 0.2f, min_size, max_size);
             x_temp = Camera.main.transform.position.x - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
             y_temp = Camera.main.transform.position.y - Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, 0, 0)).y;
         }
         */
        //движение камеры(лево-право)
        /*if (Input.mousePosition.x > Screen.width - 10)
		{
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + 0.1f, -3.8f, 3.8f), transform.position.y, -10);
        }
        else if(Input.mousePosition.x < 10)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - 0.1f, -3.8f, 3.8f), transform.position.y, -10);
        }*/
        /*//движение камеры(вверх-вниз)
        if (Input.mousePosition.y > Screen.height - 10)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + 0.1f, -2.3f, 2.3f), -10);
        }
        else if (Input.mousePosition.y < 10)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - 0.1f, -2.3f, 2.3f), -10);
        }
        */
    }



    /// <summary>
    /// Возвращает обьект под курсором
    /// </summary>
    public GameObject GetObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            return(hit.collider.gameObject);
        }
        return null;
    }
}
