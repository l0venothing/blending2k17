using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public int rooms = 1;

	// Use this for initialization
	void Start () {

        int numberOfDoor = System.Math.Min(Random.Range(2, 7), rooms);
        int length = numberOfDoor * 3 + Random.Range(0,5);

        List<int> doors = new List<int>();
        doors.Add(2);

        int doorIndex = 0;

        GameObject exit = NewRoom(new Vector3(0,0,0), "ground_floor", doors, length);
	}

	// Update is called once per frame
	void Update () {

	}

    private GameObject NewRoom(Vector3 position, string name, List<int> doors, int length, GameObject origin=null, bool outNeeded=true){

        GameObject room = Instantiate(Resources.Load("room")) as GameObject;
        room.transform.localPosition = position;
        GenerateRoom generate = room.GetComponent<GenerateRoom>();

        generate.length = length;
        generate.doors = doors;
        generate.textureName = name;
        generate.Initialize(origin);

        return null;
    }
}
