using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour {

    public GameObject parent;
    public DoorManager destination;
    private bool PlayerInTrigger;
    private GameObject player;
    private bool doorOpening = false;
    private bool fade_out = false;
    private bool fade_in = false;
    public AudioSource audio;


	// Use this for initialization
	void Start () {
        PlayerInTrigger = false;
        audio = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update () {
        if(doorOpening)
        {
            if(fade_out){
                GameObject image = GameObject.FindGameObjectWithTag("Fade");
                Color col = image.GetComponent<Image>().color;
                col.a += Time.deltaTime * 20;

                if(col.a >= 1f){
                    col.a = 1f;
                    audio.Play();
                    fade_out = false;
                }
                image.GetComponent<Image>().color = col;
            }
            else if(!audio.isPlaying && !fade_in){
                fade_in = true;
                destination.parent.active = true;
                Vector3 pos = player.transform.position;
                pos.x =  destination.transform.position.x;
                player.transform.position = pos;
            }
            else if(fade_in){
                GameObject image = GameObject.FindGameObjectWithTag("Fade");
                Color col = image.GetComponent<Image>().color;
                col.a -= Time.deltaTime * 20;

                if(col.a <= 0f){
                    col.a = 0f;
                    fade_in = false;
                    doorOpening = false;
                    parent.active = false;
                    // :D
                }
                image.GetComponent<Image>().color = col;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (PlayerInTrigger)
            {
                OpenDoor();
            }
        }
	}

    public void OpenDoor(){
        doorOpening = true;
        fade_out = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Player")
        {
            PlayerInTrigger = true;
            player = other.gameObject;
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
