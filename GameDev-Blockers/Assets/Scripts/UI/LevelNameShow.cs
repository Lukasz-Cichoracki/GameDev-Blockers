using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNameShow : MonoBehaviour
{
    public AllLevels lvls;
    public int levelIndex = 0;
    private TextMeshProUGUI levelText;
    private void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = $"Level {levelIndex+1} - {lvls.levels[levelIndex]}";
    }
}
