using UnityEngine;
using UnityEngine.Serialization;

public class Bread : DropItem
{
    [SerializeField] int addHp = 1;
    [SerializeField] Material screenMat;
    [SerializeField] [ColorUsage(true, true)] Color screenColor;
    [SerializeField] GameObject breadEffectObj;
    [SerializeField] RectTransform breadRectTransform;
    [SerializeField] float continueTime = .5f;

    public override void CatchEffect()
    {
        GameManager.Instance.UpdateHp(addHp);
        
        AudioManager.Instance.PlayBreadGetAudio();
        //TODO: show effect.
        screenMat.color = screenColor;
        screenMat.SetFloat("_Intensity", .3f);
        breadRectTransform.anchoredPosition = 
            new Vector2(Random.Range(-0.3f,0.3f) * Screen.currentResolution.width ,Random.Range(-0.4f,-0.2f) * Screen.currentResolution.height);
        breadRectTransform.localScale = Vector3.one * Random.Range(1f, 1.5f);
        GameObject breadEffect = Instantiate(breadEffectObj, GameManager.Instance.UiManager.transform);
        Destroy(breadEffect, continueTime);
    }

}
