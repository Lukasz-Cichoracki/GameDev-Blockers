
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

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            if (transform.position.x == direction * 5.5)
            {
                transform.position += _toStartPosition;
                continue;
            }
            transform.position += _logMove;         
        }
    }

    private void Start()
    {
        _toStartPosition = new Vector3(direction * -10f, 0f, 0f);
        _logMove = new Vector3(direction * 1f, 0f, 0f);
        StartCoroutine(Move());
    }

    private void Update()
    {
     
    }
}
