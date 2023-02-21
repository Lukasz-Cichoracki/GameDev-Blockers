using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecpointsScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            PlayerMovement.playerRespawn = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
