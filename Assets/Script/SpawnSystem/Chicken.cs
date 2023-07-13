using System;
using Cinemachine;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    static Camera mainCamera;
    public ChickenSpawn chickenSpawn;
    [SerializeField] Transform child;
    CinemachineDollyCart cart;
    float continueTime = 10;
    float timer;
    float switchTimer;
    float nowPos;
    float switchTime;

    void Start()
    {
        
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        cart = GetComponent<CinemachineDollyCart>();
        switchTime = cart.m_Path.PathLength / cart.m_Speed/2;
    }

    void Update()
    {
        timer += Time.deltaTime;
        switchTimer += Time.deltaTime;
        child.LookAt(mainCamera.transform,Vector3.up);

        if (switchTimer > switchTime)
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x * -1,localScale.y,localScale.z);
            transform.localScale = localScale;
            switchTimer = 0;
        }
        
        if (timer >= continueTime)
        {
            chickenSpawn.nowChicken--;
            Destroy(gameObject);
        }
    }
}
