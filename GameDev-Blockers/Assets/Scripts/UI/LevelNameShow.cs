using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNameShow : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = SceneManager.GetActiveScene().name;
    }
}
