using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed =0.9f;
    float translation;
    public AudioSource audiosource;

    public Animator animator;
    void Start()
    {
        audiosource=GetComponent<AudioSource>();
    }
    void Update()
    {
         translation= Time.deltaTime * speed;
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
           
            transform.Translate(translation, 0, 0);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
            animator.SetBool("iddle", false);
            GetComponent<SpriteRenderer>().flipX = false;
          
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            
            transform.Translate(-translation, 0, 0);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
          
            animator.SetBool("iddle", false);
            GetComponent<SpriteRenderer>().flipX = true;
           
         
        }
        else{
            animator.SetBool("iddle", true);
            if (audiosource.isPlaying)
            {
                audiosource.Stop();
            }



        }
    }
}
