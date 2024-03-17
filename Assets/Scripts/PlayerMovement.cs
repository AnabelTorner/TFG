using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;

    //private Animator anim;
    //private AudioSource sound;

    //public AudioClip SFXfootSteps;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        //sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        inputs = Vector3.zero;

        //Walk
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
        transform.forward = Vector3.forward;

        rb.MovePosition(rb.position + inputs * Speed * Time.fixedDeltaTime);

        bool hasHorizontalInput = !Mathf.Approximately(inputs.x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(inputs.z, 0f);
        //bool isWalking = hasHorizontalInput || hasVerticalInput;
        //anim.SetBool("IsWalking", isWalking);
        /*
        if (isWalking)
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        */
    }
}
