﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private float modifiedSpeed;
    private Vector3 movementDirection; 
    public Animator animator;


    void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public float GetCurrentSpeed()
    {
        return modifiedSpeed;
    }

    public Vector3 GetMovementDirection()
    {
        return movementDirection;
    }

    void Update()
    {
        bool fire1Down = Input.GetButtonDown("Fire1");
        bool fire1Pressed = Input.GetButton("Fire1");
        bool fire1Up = Input.GetButtonUp("Fire1");

        bool fire2Down = Input.GetButtonDown("Fire2");
        bool fire2Pressed = Input.GetButton("Fire2");
        bool fire2Up = Input.GetButtonUp("Fire2");

        animator.SetBool("fire1", false);
        animator.SetBool("fire2", false);

        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);

        // animation for the player.
        if(movementDirection != Vector3.zero)
        {
            if(movementDirection.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }
}
