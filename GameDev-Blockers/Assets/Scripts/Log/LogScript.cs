
using System.Collections;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    [SerializeField] private float speed=0.09f;
    [SerializeField] private int direction=1;
    private Transform playerTransform;
    private float playerPosX;

    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(speed);
            GameManager.MoveGameObject(this.transform, direction);
            if (playerTransform != null && (!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.S) || !Input.GetKeyDown(KeyCode.D)))
            {
                playerTransform.position += GameManager.move*direction;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            playerTransform = collision.transform;
            playerTransform.position = this.transform.position;
        }
        if (collision.tag == "teleport" && direction == -1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("teleport2");
            transform.position = new Vector3(obj.transform.position.x , transform.position.y, transform.position.z);
        }
        if (collision.tag == "teleport2" && direction == 1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("teleport");
            transform.position = new Vector3(obj.transform.position.x , transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player" && PlayerMovement.PlayerCollision.IsTouchingLayers(1<<3))
        {
            playerPosX = playerTransform.position.x;
            playerPosX = Mathf.Round(playerPosX);
            playerTransform.position = new Vector3(playerPosX, playerTransform.position.y, playerTransform.position.z);
        }
        if (collision.tag == "player")
        {
            playerTransform = null;
        }
        
    }
}
