
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public static Collider2D PlayerCollision { get; private set; }
    public static Vector3 playerRespawn = new Vector3();
    private bool isAlive = true;
    [SerializeField] private GameObject cameraObject;

    private float timeBetweenMoves = 0.0333f;
    private float timestamp;

    private void Start()
    {
        PlayerCollision = this.GetComponent<Collider2D>();
        playerRespawn = this.transform.position;
        isAlive = true;
    }
    private void Update()
    {

        Move();
        if (!isAlive)
        {
            transform.position = playerRespawn;
            cameraObject.transform.position = new Vector3(0f, this.transform.position.y + 2.5f, 0f);
        }
        if (!PlayerCollision.IsTouchingLayers(1 << 3) && !PlayerCollision.IsTouchingLayers(1 << 6))
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
    }

    private void Move()
    {
        if (Time.time >= timestamp)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += Vector3.up;
                cameraObject.transform.position += Vector3.up;
                timestamp = Time.time +timeBetweenMoves;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left;
                timestamp = Time.time + timeBetweenMoves;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
                timestamp = Time.time + timeBetweenMoves;
            }
        }
        
    }
}