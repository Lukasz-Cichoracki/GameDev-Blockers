using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed=0.1f;
    public int direction = 1;
    IEnumerator EnemyMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpeed);
            GameManager.MoveGameObject(this.transform, direction);
        }
    }
    private void Start()
    {
        StartCoroutine(EnemyMove());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            SceneManager.LoadScene(0);
        }

    }
}
