using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nmeScript : MonoBehaviour {
    public GameObject player;
    public float nmeSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float acceleration;
    public Vector2 distanceWithPlayer;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        distanceWithPlayer = transform.position - player.transform.position;
      if (distanceWithPlayer.x< 10 )
        {
            nmeSpeed += acceleration * Time.deltaTime;
            Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * nmeSpeed, 0);
            GetComponent<Rigidbody2D>().velocity = -velocity;

        }

        if (distanceWithPlayer.x > 1)
        {
            nmeSpeed = 0;
            //lancer combat
        }


    }
}
