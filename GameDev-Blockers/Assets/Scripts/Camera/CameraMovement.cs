
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(0f, player.transform.position.y+2.5f, 0f);
        }
    }
}
