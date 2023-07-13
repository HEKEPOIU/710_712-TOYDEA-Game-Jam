using UnityEngine;

public class Egg : DropItem
{
    [SerializeField] int subHp = 1;
    [SerializeField] float continueTime = 1f;
    [SerializeField] GameObject[] eggEffectObj;
    [SerializeField] RectTransform[] eggRectTransform;

    void Start()
    {
        base.Start();

    }
    
    public override void CatchEffect()
    {
        GameManager.Instance.UpdateHp(-subHp);
        
        AudioManager.Instance.PlayEggGetAudio();


        int index = Random.Range(0, eggEffectObj.Length);
        eggRectTransform[index].anchoredPosition = 
            new Vector2(Random.Range(-0.5f,0.5f) * Screen.currentResolution.width ,Random.Range(-0.5f,0.5f) * Screen.currentResolution.height);
        eggRectTransform[index].localScale = Vector3.one * Random.Range(1.5f, 3f);
        GameObject eggEffect = Instantiate(eggEffectObj[index], GameManager.Instance.UiManager.transform);
        Destroy(eggEffect, continueTime);
    }

    void Update()
    {
        base.Update();
        transform.LookAt(MainCamera.transform);
    }



}
