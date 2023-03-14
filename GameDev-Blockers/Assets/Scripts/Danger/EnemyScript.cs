using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float enemySpeed=0.1f;
    [SerializeField] private int direction = 1;
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
        if (collision.tag == "teleport" && direction == -1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("teleport2");
            transform.position = new Vector3(obj.transform.position.x, transform.position.y, transform.position.z);
        }
        if (collision.tag == "teleport2" && direction == 1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("teleport");
            transform.position = new Vector3(obj.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

