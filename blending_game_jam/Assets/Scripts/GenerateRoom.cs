using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour {

    public string textureName;
    public int length = 3;
    public List<int> doors;


	// Use this for initialization
	public void Initialize () {
        for(int index=0; index<length; index++){
            Room(index);
        }
	}

    void Room(int number){

        //compute position
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = number * 6f;


        // load game object
        GameObject bg_gameobject;

        if(doors.Contains(number)){
            bg_gameobject = Instantiate(Resources.Load("room_door")) as GameObject;
            bg_gameobject.GetComponent<DoorManager>().parent = gameObject;
        }
        else{
            bg_gameobject = Instantiate(Resources.Load("room_bg")) as GameObject;
        }

        bg_gameobject.transform.parent = transform;

        // find good bg
        GameObject border = Instantiate(Resources.Load("room_bg")) as GameObject;
        border.transform.parent = transform;
        border.name = "border_" + number;

        // load good sprites for bg
        string name = "room_bg_";
        if(doors.Contains(number)){
            name += "door_";
        }
        Sprite bgSprite;
        bgSprite = Resources.Load<Sprite>(name + textureName);


        Sprite borderSprite;
        if(number == 0){
            borderSprite = Resources.Load<Sprite>("border_left");
        }
        else if(number == length -1){
            borderSprite = Resources.Load<Sprite>("border_right");
        }
        else{
            borderSprite = Resources.Load<Sprite>("border_middle");
        }

        // make good sprite in game object
        SpriteRenderer spriteRender = bg_gameobject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = bgSprite;
        spriteRender.sortingOrder = -1;


        SpriteRenderer spriteBorderRender = border.GetComponent<SpriteRenderer>();
        spriteBorderRender.sprite = borderSprite;
        spriteBorderRender.sortingOrder = 1;

        //place object
        bg_gameobject.transform.localPosition = pos;
        border.transform.localPosition = pos;

    }

	// Update is called once per frame
	void Update () {

	}
}
