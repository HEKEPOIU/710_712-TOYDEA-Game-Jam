using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyDrop : MonoBehaviour
{
    [SerializeField] UnityEvent onCollide;

    void OnCollisionEnter2D(Collision2D other)
    {
        onCollide.Invoke();
    }
}
