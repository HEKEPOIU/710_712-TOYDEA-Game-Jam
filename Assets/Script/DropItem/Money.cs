using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Money :DropItem
{
    [SerializeField] int moneyValue = 1;
    [SerializeField] GameObject moneyEffectObj;
    [SerializeField] RectTransform moneyRectTransform;
    [SerializeField] float continueTime = .5f;
    
    


    public override void CatchEffect()
    {
        GameManager.Instance.UpdateMoney(moneyValue);
        
        AudioManager.Instance.PlayMoneyGetAudio();
        //-.5 -> 0

        moneyRectTransform.anchoredPosition = 
            new Vector2(Random.Range(-0.3f,0.3f) * Screen.currentResolution.width ,Random.Range(-0.4f,-0.2f) * Screen.currentResolution.height);
        moneyRectTransform.localScale = Vector3.one * Random.Range(1f, 1.5f);
        GameObject eggEffect = Instantiate(moneyEffectObj, GameManager.Instance.UiManager.transform);
        Destroy(eggEffect, continueTime);
    }

}

