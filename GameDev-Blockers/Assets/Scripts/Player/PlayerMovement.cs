using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private GameObject _log;
    private bool _isMoving=false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.position += new Vector3(0f, 1f, 0f);
        else if (Input.GetKeyDown(KeyCode.A))
            transform.position += new Vector3(-1f, 0f, 0f);
        else if (Input.GetKeyDown(KeyCode.D))
            transform.position += new Vector3(1f, 0f, 0f);

      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "log")
        {
           _log = collision.gameObject;
            Debug.Log("dupa");
            _isMoving = true;
        }
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "log")
            _isMoving = false;
    }
}
