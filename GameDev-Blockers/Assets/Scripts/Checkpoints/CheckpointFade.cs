using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CheckpointFade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fadeText;
    private float fade = 0;
    IEnumerator Fade()
    {
        do
        {
            yield return new WaitForSeconds(0.05f);
            if(fadeText.alpha >= 0)
            {
                fadeText.alpha += Time.deltaTime;
            }
            if(fadeText.alpha <= 255)
            {
                fadeText.alpha -= Time.deltaTime;
            }

        }while (fade > 0);
    }

    private void Start()
    {
        fadeText.alpha = fade;
        StartCoroutine(Fade());
    }
}
