﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasperControls : MonoBehaviour {

    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("isThrowNormal");
        }
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("isThrowFast");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("isHipHop");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("isStopDance");
        }

        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);

        }

        
	}
}
