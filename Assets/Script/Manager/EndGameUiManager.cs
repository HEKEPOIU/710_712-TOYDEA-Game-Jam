using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUiManager : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button backTitleButton;
    [SerializeField] Button endGameButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Content");
            GameManager.Instance.ResetGameValue();
        });
        backTitleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Start");
            GameManager.Instance.ResetGameValue();
        });
        endGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
