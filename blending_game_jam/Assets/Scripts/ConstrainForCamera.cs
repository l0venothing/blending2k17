using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainForCamera : MonoBehaviour {
    public GameObject player;
    public GameObject generator;
    private Vector3 offset;
    private float x_max;
    private float x_min;
    private Transform[] sides;
    private Transform rightSide;
    private Transform leftSide;
    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        sides=generator.GetComponentsInChildren<Transform>();

        foreach (Transform child in sides)
        {
            if (child.tag == "CamBlock-L")
            {
                leftSide = child;
            }
            if (child.tag == "CamBlock-R")
            {
                rightSide = child;
            }
        }
        x_min= leftSide.transform.position.x;
        x_max = rightSide.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        CameraMove();
    }

    void CameraMove()
    {
        transform.position = new Vector3(player.transform.position.x - offset.x, transform.position.y, transform.position.z);
        transform.position = new Vector3 (Mathf.Clamp(GetComponent<Camera>().transform.position.x, x_min, x_max), transform.position.y,transform.position.z);
    }
}
