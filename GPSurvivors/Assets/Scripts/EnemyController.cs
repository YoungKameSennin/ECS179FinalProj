using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    private GameObject player;
    private Transform playerTransform;

    private float modifiedSpeed;
    private Vector3 movementDirection; 

    void Awake()
    {
        player = GameObject.Find("Player");
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
        playerTransform = player.transform;
        movementDirection = player.transform.position - this.transform.position;
        movementDirection.Normalize();
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);
    }
}