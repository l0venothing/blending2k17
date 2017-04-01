using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {
 
    public GameObject parent;
    public GameObject destination;
    private bool PlayerInTrigger;

	// Use this for initialization
	void Start () {
        PlayerInTrigger = false;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (PlayerInTrigger)
            {
                OpenDoor();
            }
        }
	}

    public void OpenDoor(){
        print("Door open!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Player")
        {
            PlayerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInTrigger = false;
        }
    }
}
