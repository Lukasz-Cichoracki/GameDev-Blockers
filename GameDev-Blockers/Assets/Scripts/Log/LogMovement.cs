
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
    private Vector3 _toStartPosition;
    private Transform _playerTransform;
    private GameObject _water;

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if (transform.position.x == direction * 6.5)
            {
                transform.position += _toStartPosition;
                continue;
            }
            transform.position += _logMove;
            if (_playerTransform != null)
            {
                _playerTransform.position = this.transform.position;
            }
        }
    }

    private void Start()
    {
        _toStartPosition = new Vector3(direction * -12f, 0f, 0f);
        _logMove = new Vector3(direction * 1f, 0f, 0f);
        StartCoroutine(Move());
    }

    private void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            _playerTransform = collision.transform;
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            _playerTransform = null;
        }
        
    }
}
