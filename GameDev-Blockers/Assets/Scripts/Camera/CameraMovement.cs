
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, 1f, 0f);
        }
    }
}
