
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Vector3 move;
    
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
        move = new Vector3(0.25f, 0f, 0f);
    }

    public static void MoveGameObject(Transform objPosition, int direction)
    {
        objPosition.position += move * direction;
    }

}
