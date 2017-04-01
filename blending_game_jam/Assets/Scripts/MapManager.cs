using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public const string CORRIDOR = "first_floor";
    public const string BED_ROOM = "ground_floor";

    public int rooms = 5;
    private bool firstRoom = true;

	// Use this for initialization
	void Start () {
        int _rooms = rooms;
        int index = 0;
        while(_rooms > 0){
            int roomsGenerated = AddRoom(index++);
            _rooms -= roomsGenerated;
            print(_rooms);
        }
	}

	// Update is called once per frame
	void Update () {

	}

    private int AddRoom(int index){
        int numberOfDoor = System.Math.Min(Random.Range(2, 7), rooms);
        numberOfDoor = System.Math.Max(numberOfDoor, 1);

        List<int> doors = new List<int>();

        int roomsGenerated = numberOfDoor - 1;

        if(firstRoom){
            firstRoom = false;
            roomsGenerated++;
        }
        int doorIndex = 0;

        while(numberOfDoor > 0){
            doorIndex += Random.Range(0,2);
            doors.Add(doorIndex);
            doorIndex += 2;
            numberOfDoor--;
        }

        int length = doorIndex;
        GameObject newRoom = NewRoom(new Vector3(0,0,index * 12), CORRIDOR, doors, length);

        if(index > 0){}

        return roomsGenerated;

    }

    private GameObject NewRoom(Vector3 position, string name, List<int> doors, int length, GameObject origin=null, bool outNeeded=true){

        GameObject room = Instantiate(Resources.Load("room")) as GameObject;
        room.transform.localPosition = position;
        GenerateRoom generate = room.GetComponent<GenerateRoom>();

        generate.length = length;
        generate.doors = doors;
        generate.textureName = name;
        generate.Initialize(origin);

        return room;
    }
}
