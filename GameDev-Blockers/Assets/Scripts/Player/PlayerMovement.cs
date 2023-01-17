using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    private GameObject _log;
  
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

    }

}
