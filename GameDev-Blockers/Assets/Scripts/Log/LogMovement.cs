
using System.Collections;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private int logSpeed;
    public int LogSpeed
    {
        get { return logSpeed; }
        set {
            if (value > 0)
                logSpeed = value;
            else
                logSpeed = 1;
            }
    }
    public int direction=1;

    private Vector3 _logMove;
    private Transform _playerTransform;
    private float _playerPosX;

    private Vector3 _toStartPosition;

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if (transform.position.x == direction * 6.75)
            {
                transform.position += _toStartPosition;
                continue;
            }
            transform.position += _logMove;
            if (_playerTransform != null && (!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.S) || !Input.GetKeyDown(KeyCode.D)))
            {
                _playerTransform.position += new Vector3(direction*0.25f,0f,0f);
            }
        }
    }

    private void Start()
    {
        _toStartPosition = new Vector3(direction * -14f, 0f, 0f);
        _logMove = new Vector3(direction * 0.25f, 0f, 0f);
        StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            _playerTransform = collision.transform;
            _playerTransform.position = this.transform.position;
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player" && PlayerMovement.playerCollision.IsTouchingLayers(1<<3))
        {
            _playerPosX = _playerTransform.position.x;
            _playerPosX = Mathf.Round(_playerPosX);
            _playerTransform.position = new Vector3(_playerPosX, _playerTransform.position.y, _playerTransform.position.z);
        }
        if (collision.tag == "player")
        {
            _playerTransform = null;
        }   
    }
}
