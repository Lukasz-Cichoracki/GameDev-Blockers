using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
