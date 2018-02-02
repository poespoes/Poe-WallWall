﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

    public float moveSpeed;
    public float jumpSpeed;

    private bool topTouch;
    private bool bottomTouch;

    private Rigidbody2D rb;
    private Animator anim;

    public float deathTimer = 0;
   
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKey(rightKey)) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(leftKey)) {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(upKey)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyDown(downKey)) {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
        }
      
        topTouch = false;
        bottomTouch = false;
    }

    // Wall bounce
    private void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.gameObject.tag == "wallTop")&& (collision.gameObject.tag == "wallBottom")) {
            Debug.Log("RIP RESPAWN!");
            transform.position = new Vector3(-6f, 2.5f, 0);
        }


        /*if (collision.gameObject.tag == "wallTop"){
            topTouch = true;
            Debug.Log("RIP RESPAWN!");
            transform.position = new Vector3(-6f, 2.5f, 0);
        }

        if (collision.gameObject.tag == "wallBottom"){
            bottomTouch = true;
            transform.position = new Vector3(-6f, 2.5f, 0);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ((collision.gameObject.tag == "wallTop") && (collision.gameObject.tag == "wallBottom")) {
            Debug.Log("RIP RESPAWN!");
            transform.position = new Vector3(-6f, 2.5f, 0);
        }
    }

}

