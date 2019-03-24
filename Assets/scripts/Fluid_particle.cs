using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid_particle : MonoBehaviour {
    public int part_id;
    public float mass;
    public float ro;
    public float ro_near;
    public float press;
    public float press_near;
    public Vector2 a;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GetComponent<Rigidbody2D>().AddForce(a*mass);
    }
}
