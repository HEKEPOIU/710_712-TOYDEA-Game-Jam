using System;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] float speed;
    static Transform target;
    public float Speed { get => speed; set => speed = value; }
    float timer = 5;
    [SerializeField] float rotateSpeed;
    static protected Camera MainCamera;

    protected void Start()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }
        
        if (target == null)
        {
            target = FindObjectOfType<CatchPlane>().transform;
        }
        AudioManager.Instance.PlayThrowAudio();
    }

    protected void Update()
    {
        timer-= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * (Time.deltaTime * speed), Space.World);
    }
    
    public virtual void CatchEffect()
    {
        
    }


    public void AddSpeed(float addSpeed)
    {
        speed += addSpeed;
    }
}
