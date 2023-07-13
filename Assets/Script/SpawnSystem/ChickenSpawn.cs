using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ChickenSpawn : MonoBehaviour
{
    CinemachineSmoothPath path;
    CinemachineDollyCart dollyCart;
    [FormerlySerializedAs("chicken")] [SerializeField] GameObject chickenObj;
    Chicken chicken;
    [SerializeField] int maxChicken = 3;
    public int nowChicken;
    [SerializeField] float initSpeed;
    [SerializeField] float minSpeed = 5;
    [SerializeField] float maxSpeed = 10;
    float timer;

    void Start()
    {
        path = GetComponent<CinemachineSmoothPath>();
        dollyCart = chickenObj.GetComponent<CinemachineDollyCart>();
        chicken = chickenObj.GetComponent<Chicken>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && nowChicken <= maxChicken)
        {
            timer = initSpeed;
            dollyCart.m_Speed = Random.Range(minSpeed, maxSpeed);
            dollyCart.m_Path =  path;
            chicken.chickenSpawn = this;
            Instantiate(chicken, path.m_Waypoints[0].position, Quaternion.identity);
            nowChicken++;
        }
    }
}
