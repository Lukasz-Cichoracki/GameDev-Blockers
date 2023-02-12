
using System.Collections;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float speed=0.1f;
    public int direction=1;
    private Transform _playerTransform;
    private float _playerPosX;

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(speed);
            GameManager.MoveGameObject(this.transform, direction);
            if (_playerTransform != null && (!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.S) || !Input.GetKeyDown(KeyCode.D)))
            {
                _playerTransform.position += GameManager.move*direction;
            }
        }
    }

    private void Start()
    {
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
