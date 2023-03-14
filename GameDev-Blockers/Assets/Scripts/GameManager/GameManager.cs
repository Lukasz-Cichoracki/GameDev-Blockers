
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Vector3 toStartPosition;
    public static Vector3 move;
    public static float teleportPos = 6.75f;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        toStartPosition = new Vector3(-14f, 0f, 0f);
        move = new Vector3(0.25f, 0f, 0f);
    }

    public static void MoveGameObject(Transform objPosition, int direction)
    {
        if (objPosition.position.x==direction*teleportPos)
        {
            objPosition.position += toStartPosition * direction;
            return;
        }
        objPosition.position += move * direction;
    }
}
