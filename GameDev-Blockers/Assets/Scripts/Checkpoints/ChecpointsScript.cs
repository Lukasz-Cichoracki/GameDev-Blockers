using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChecpointsScript : MonoBehaviour
{
    private GameObject fadeObject;
    private TextMeshProUGUI fadeText;
    [SerializeField] private GameObject allMovables;
    private void Start()
    {
        fadeObject = GameObject.Find("CheckpointText");
        fadeText = fadeObject.GetComponent<TextMeshProUGUI>();
    }
    private IEnumerator Fade()
    {
        if (fadeText != null)
        {
            Color currentColor = fadeText.color;
            while (fadeText.color.a < 1)
            {
                yield return new WaitForSeconds(0.04f);
                currentColor.a += 0.05f;
                fadeText.color = currentColor;
            }
            while (fadeText.color.a > 0)
            {
                yield return new WaitForSeconds(0.04f);
                currentColor.a -= 0.05f;
                fadeText.color = currentColor;
            }
            currentColor.a = 0;
            fadeText.color = currentColor;
            Destroy(allMovables);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            PlayerMovement.playerRespawn = this.transform.position;
            StartCoroutine("Fade");        
        }
    }
}
