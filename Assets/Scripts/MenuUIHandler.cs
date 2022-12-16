using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestScore;

    private void Start()
    {
        if(MenuMainManager.Instance != null)
        {
            BestScore.text = $"Best Score {MenuMainManager.Instance.BestScore}";
        }
    }
    public void StartGame()
    {
        if (MenuMainManager.Instance.PlayerName == null) return;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveName(string name)
    {
        MenuMainManager.Instance.PlayerName = name;
    }
}
