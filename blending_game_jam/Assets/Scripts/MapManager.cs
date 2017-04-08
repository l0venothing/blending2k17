using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public const string CORRIDOR = "first_floor";
    public const string BED_ROOM = "ground_floor";

    public int rooms = 5;
    private bool firstRoom = true;
    private DoorManager origin;

    // Use this for initialization
    void Start () {
        int _rooms = rooms;
        int index = 0;
        while(_rooms > 0){
            int roomsGenerated;
            if(index == 0){
                roomsGenerated = AddRoom(index++);
            }
            else{
                roomsGenerated = AddRoom(index++, origin);
            }
            _rooms -= roomsGenerated;
        }
	}

	// Update is called once per frame
	void Update () {

	}

    private int AddRoom(int index, DoorManager origin=null){
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
        GameObject newRoom = NewRoom(new Vector3(0,0,index * 12), CORRIDOR, doors, length, origin);
        if(index == 0){
            newRoom.active = true;
        }

        GenerateRoom genRoom = newRoom.GetComponent<GenerateRoom>();
        this.origin = genRoom.doorsList[genRoom.doorsList.Count -1];


        int indexBegin = 0;
        if(index > 0){
            indexBegin +=1;
        }

        for(int idx=indexBegin; idx < genRoom.doorsList.Count -1; idx++){
            DoorManager doorMan = genRoom.doorsList[idx];
            Vector3 bdPos = new Vector3(idx * 24, 0, index * 12 + 6);

            doors = new List<int>();
            doors.Add(1);
            GameObject nr = NewRoom(bdPos, BED_ROOM, doors, 3, doorMan);
        }

        return roomsGenerated;

    }

    private GameObject NewRoom(Vector3 position, string name, List<int> doors, int length, DoorManager origin=null, bool outNeeded=true){

        GameObject room = Instantiate(Resources.Load("room")) as GameObject;
        room.transform.localPosition = position;
        GenerateRoom generate = room.GetComponent<GenerateRoom>();

        generate.length = length;
        generate.doors = doors;
        generate.textureName = name;
        generate.Initialize(origin);
        room.active = false;
        room.transform.parent = transform;
        return room;
    }
}
