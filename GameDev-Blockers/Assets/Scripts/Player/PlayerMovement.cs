using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private GameObject _log;
    private Collider2D _playerCollision;
    private bool _isAlive = true;

    private void Start()
    {
        _playerCollision = this.GetComponent<Collider2D>();
        _isAlive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, 1f, 0f);
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
        if (!_playerCollision.IsTouchingLayers(1 << 3))
        {
            _isAlive = false;
        }
         
     

    }
}
