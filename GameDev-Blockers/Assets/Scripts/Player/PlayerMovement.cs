using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public static Collider2D playerCollision { get; private set; }
    private bool _isAlive = true;
    public GameObject cameraObject;

    private void Start()
    {
        playerCollision = this.GetComponent<Collider2D>();
        _isAlive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, 1f, 0f);
            cameraObject.transform.position += new Vector3(0f, 1f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0f, 0f);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0f, 0f);
        }
        if(!_isAlive)
        {
            SceneManager.LoadScene(0);
        }
        if (!playerCollision.IsTouchingLayers(1 << 3) && !playerCollision.IsTouchingLayers(1 << 6))
        {
            _isAlive = false;
        }
       
     

    }
}
