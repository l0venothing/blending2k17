using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed =0.9f;
    float translation;
    void Start()
    {

    }
    void Update()
    {
         translation= Time.deltaTime * speed;
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(translation, 0, 0);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-translation, 0, 0);
        }
    }
}
