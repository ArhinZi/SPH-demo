using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SPH_copy : MonoBehaviour {
    List<GameObject>[,] _grid;
    public float _grid_width;
    public float _grid_height;
    public float scale;
    public int particles_count = 0;
    public List<GameObject> particles;
    public List<GameObject>[] part_near;

    public float mass;
    public float h;
    public float k;
    public float rest_ro;

    // Use this for initialization
    void Start() {
        _grid_width = _grid_width / scale;
        _grid_height = _grid_height / scale;
        _grid = new List<GameObject>[(int)(_grid_width), (int)(_grid_height)];

        h = (float)(1.42 * (scale * (1 + 0.5)));

        for (int i = 0; i < _grid_width; i++)
        {
            for (int j = 0; j < _grid_height; j++)
            {
                _grid[i, j] = new List<GameObject>();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        part_near = new List<GameObject>[particles_count];
        for (int i = 0; i < _grid_width; i++)
        {
            for (int j = 0; j < _grid_height; j++)
            {
                _grid[i, j].Clear();
            }
        }

        for (int i = 0; i < particles_count; i++)
        {
            int x = (int)((particles[i].transform.position.x + _grid_width/2 ));
            int y = (int)((particles[i].transform.position.y + _grid_height/2));
            _grid[x, y].Add(particles[i]);
        }

        for (int i = 0; i < particles_count; i++)
        {
            Fluid_particle g = particles[i].GetComponent<Fluid_particle>();
            g.ro = 0;
            g.ro_near = 0;
            g.press = 0;
            g.press_near = 0;
            part_near[i] = near_part(i);
        }
        foreach(GameObject i in part_near[0])
        {
            Debug.Log(i.name);
            Debug.Log("x" +(int)(i.transform.position.x + _grid_width / 2));
            Debug.Log("y" +(int)(i.transform.position.y + _grid_height / 2));
            Debug.Log("k" + h);
        }
    }

    List<GameObject> near_part(int i)
    {
        List<GameObject> l = new List<GameObject>();
        int x = (int)((particles[i].transform.position.x + _grid_width / 2));
        int y = (int)((particles[i].transform.position.y + _grid_height / 2));
        l.AddRange(_grid[x, y]);

        if (x - 1 >= 0 && y + 1 <= _grid_height) l.AddRange(_grid[x-1, y+1]);
        if (x - 1 >= 0) l.AddRange(_grid[x-1, y]);
        if (y - 1 >= 0) l.AddRange(_grid[x, y-1]);
        if (y - 1 >= 0 && x + 1 <= _grid_width) l.AddRange(_grid[x+1, y-1]);
        if (y + 1 <= _grid_height) l.AddRange(_grid[x, y+1]);
        if (x + 1 <= _grid_width && y + 1 <= _grid_height) l.AddRange(_grid[x+1, y+1]);
        if (x + 1 <= _grid_width) l.AddRange(_grid[x+1, y]);
        if (x - 1 > 0 && y - 1 > 0) l.AddRange(_grid[x - 1, y - 1]);
        return l;
    }
}
