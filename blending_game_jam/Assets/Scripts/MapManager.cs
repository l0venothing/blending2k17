using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    public int rooms = 1;

	// Use this for initialization
	void Start () {
        List<int> doors = new List<int>();
        doors.Add(3);
        NewRoom(new Vector3(0,0,0), doors, 4);
	}

	// Update is called once per frame
	void Update () {

	}

    void NewRoom(Vector3 position, List<int> doors, int length, GameObject origin=null){
        GameObject room = Instantiate(Resources.Load("room")) as GameObject;
        room.transform.localPosition = position;
        GenerateRoom generate = room.GetComponent<GenerateRoom>();
        generate.length = length;
        generate.doors = doors;
        generate.Initialize();
    }
}
