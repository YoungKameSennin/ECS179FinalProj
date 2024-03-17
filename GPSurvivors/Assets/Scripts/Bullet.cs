﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 50.0f;
    public float speed = 5f;
    public float rotateSpeed = 200f;//adjust if needed
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            // let bullet keep track the enemy
            Vector2 direction = (target.position - transform.position).normalized;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * rotateSpeed;
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
        else
        {
            Debug.Log("no target");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.gameObject is the reference to the collided object
        Debug.Log("Collided with " + collision.gameObject.name);
        collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        Destroy(gameObject);
    }

    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform == target)
        {
            //这里写扣血逻辑，我不太清楚enemy的构成，不知道该怎么扣血。
            target.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
    */
}