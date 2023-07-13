using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] Text hpText;
    [SerializeField] Text moneyText;
    [SerializeField] Button startButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button homePageButton;
    [SerializeField] Toggle muteButton;
    [SerializeField] Image countDownImage;
    [SerializeField] Slider audioSlider;
    [SerializeField] Text timerText;
    [SerializeField] Text circleCountText;
    Image musicIcon;
    [SerializeField] Sprite[] musicIconSprites;
 
        
    void Start()
    {
        ResetGameUi();
        AudioManager.Instance.PlayBGM();
        musicIcon = muteButton.GetComponent<Image>();
        musicIcon.sprite = !AudioManager.Instance.IsMute() ? musicIconSprites[0] : musicIconSprites[1];
        startButton.onClick.AddListener(() =>
        {
            GameManager.Instance.StartGame();
        });
        settingButton.onClick.AddListener(() =>
        {
            GameManager.Instance.StopGame(true);
        });
        continueButton.onClick.AddListener(()=>
        {
            GameManager.Instance.StopGame(false);
        });
        homePageButton.onClick.AddListener(() =>
        {
            GameManager.Instance.BackToHomePage();
            GameManager.Instance.StopGame(false);
        });
        muteButton.onValueChanged.AddListener((isOn) =>
        {
            musicIcon.sprite = isOn ? musicIconSprites[0] : musicIconSprites[1];
            AudioManager.Instance.SetVolume( isOn ? audioSlider.value : -50f);
        });
        audioSlider.onValueChanged.AddListener((val) =>
        {
            AudioManager.Instance.SetVolume(val);
        });
    }

    void ResetGameUi()
    {
        if (GameManager.IsPlay)
        {
            startPanel.SetActive(false);
            GameManager.Instance.StartGame();
        }
        else
        {
            startPanel.SetActive(true);
            GameManager.IsPlay = true;
        }
        UpdateHpUi(GameManager.Instance.Hp);
        UpdateScoreUi(GameManager.Instance.Score);
    }

    public void CountDownTextOpen()
    {
        countDownImage.gameObject.SetActive(true);
    }


    public void UpdateHpUi(int value)
    {
        hpText.text = GameManager.Instance.Hp.ToString();
    } 
    public void UpdateScoreUi(int value)
    {
        moneyText.text = GameManager.Instance.Score.ToString();
    }
    
    public void SetTimerText(float value)
    {
        timerText.text = Mathf.FloorToInt(value / 60f) + " : " + (Mathf.FloorToInt(value % 60));
    }

    public void CircleChange(int value)
    {
        circleCountText.text = value.ToString();
    }
}
