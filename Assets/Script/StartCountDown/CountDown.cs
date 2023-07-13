using System;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float time = 3f;
    [SerializeField] Sprite[] sprites;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        GameManager.Instance.isStartCount = false;
        time -= Time.deltaTime;
        int nowInt = (Mathf.CeilToInt(time));

        switch (nowInt)
        {
            case 1:
                image.sprite = sprites[0];
                break;            
            case 2:
                image.sprite = sprites[1];
                break;            
            case 3:
                image.sprite = sprites[2];
                break;
        }
        
        if (!(time <= 0)) return;
        time = 3f;
        gameObject.SetActive(false);
    }
    
    
}
