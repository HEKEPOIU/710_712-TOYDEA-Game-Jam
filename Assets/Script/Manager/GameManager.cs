using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    UIManager uiManager;
    [SerializeField] Material screenMaterial;
    [SerializeField] float flashSpeed;
    
    public UIManager UiManager
    {
        get
        {
            if (uiManager == null)
            {
                uiManager = FindObjectOfType<UIManager>();
            }

            return uiManager;
        }
    }
    [SerializeField] int victoryScore = 50;
    [SerializeField] int startHp = 10;


    public int Score { get; private set; } = 0;
    public int Hp { get; private set; }
    public static bool IsPlay { get; set; }
    [SerializeField] float addSpeed = 10f;
    static readonly int Intensity = Shader.PropertyToID("_Intensity");
    public float AddSpeed => addSpeed;
    
    [FormerlySerializedAs("CicleCount")] public int CircleCount = 0;

    float timer = 0;
    [HideInInspector] public bool isStartCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        ResetGameValue();
        
    }

    void Update()
    {
        float inten = screenMaterial.GetFloat(Intensity);
        if (inten >= 0)
        {
            screenMaterial.SetFloat(Intensity, inten - Time.deltaTime * flashSpeed);
        }
        if (!isStartCount || uiManager == null) return;
        
        timer += Time.deltaTime;
        UiManager.SetTimerText(timer);

    }


    public async void StartGame()
    {
        UiManager.CountDownTextOpen();
        await Task.Delay(3000);
        isStartCount = true;
        PlayerControl.Instance.StartRun();
        SpawnManerger.Instance.StartSpawn();
    }
    
    public void ResetGameValue()
    {
        Hp = startHp;
        Score = 0;
        PlayerControl.Instance.ResetSpeed();
    }
    
    public void CircleCountAdd()
    {
        CircleCount++;
        uiManager.CircleChange(CircleCount);
    }

    public void EndGame()
    {
        AudioManager.Instance.StopBGM();
        timer = 0;
        UiManager.SetTimerText(timer);
        if (Score >= victoryScore)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            SceneManager.LoadScene("Fail");
        }
    }

    public void UpdateMoney(int score)
    {
        Score += score;
        UiManager.UpdateScoreUi(Score);

        if (Score >= victoryScore)
        {
            EndGame();  
            return;
        }
        
        PlayerControl.Instance.AddSpeed((Score / 10f) * addSpeed);

    }

    public void StopGame(bool isStop)
    {
        Time.timeScale = isStop ? 0 : 1;
    }

    public void BackToHomePage()
    {
        AudioManager.Instance.StopBGM();
        SceneManager.LoadScene("Start");
    }

    
    public void UpdateHp(int value)
    {
        Hp += value;
        if (Hp >= startHp)
        {
            Hp = startHp;
        }
        UiManager.UpdateHpUi(Hp);

        if (Hp > 0) return;
        
        EndGame();

    }
    
    
}
