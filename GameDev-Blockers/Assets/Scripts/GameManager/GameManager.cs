
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector3 toStartPosition;
    public static Vector3 move;
    public static float teleportPos = 6.75f;
    
    private void Awake()
    {
        toStartPosition = new Vector3(-14f, 0f, 0f);
        move = new Vector3(0.25f, 0f, 0f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public static void MoveGameObject(Transform objPosition,int direction)
    {
        if (objPosition.position.x == direction * teleportPos)
        {
            objPosition.position += toStartPosition * direction;
            return;
        }
        objPosition.position += move * direction;
    }
}
