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
        float moveHorizontal = Input.GetAxis("Horizontal");
         translation= Time.deltaTime * speed;
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            //  right
            transform.Translate(translation, 0, 0);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            // left
            transform.Translate(-translation, 0, 0);
        }
    }
}
