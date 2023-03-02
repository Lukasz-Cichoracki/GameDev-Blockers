using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestoyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "log" || collision.tag == "danger")
        {
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator DestroyObjects(Vector3 checkpointPos)
    {
        while(this.gameObject.transform.position.y < checkpointPos.y)
        {
            yield return new WaitForSeconds(0.1f);
            DestroyerMoveToPos();
        }
    }
    public void DestroyerMoveToPos()
    {    
        transform.position += Vector3.up;
    }
}
