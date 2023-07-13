using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EffectMove : MonoBehaviour
{
    RectTransform rectTransform;

    [SerializeField] float speed;
    [SerializeField] Vector2 dir;
    

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += dir * (Time.deltaTime * speed) ;
    }
}
