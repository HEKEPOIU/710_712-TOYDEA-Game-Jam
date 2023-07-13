using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] CinemachineDollyCart path;
    [SerializeField] float StartMoveSpeed = 1;
    public static PlayerControl Instance;
    [SerializeField] Animator animator;
    public bool IsStart;
    float nowPos = 0;
    public bool IsCatchAble{get; private set; }

    float moveSpeed;

    static readonly int IsOpen = Animator.StringToHash("IsOpen");
    // Start is called before the first frame update

    //315
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        Instance = this;

    }

    void Start()
    {
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStart) return;
        if (Input.GetKey(KeyCode.Space))
        {
            IsCatchAble = true;
        }
        else
        {

            IsCatchAble = false;
        }

        if (nowPos > path.m_Position)
        {
            GameManager.Instance.CircleCountAdd();
            nowPos = path.m_Position;
        }
        nowPos = path.m_Position;
        animator.SetBool(IsOpen,IsCatchAble);
    }
    
    public void StartRun()
    {
        moveSpeed = StartMoveSpeed;
        AddSpeed(0);
        IsStart = true;

    }

    public void AddSpeed(float speed)
    {
        path.m_Speed = moveSpeed + speed;
    }

    public void ResetSpeed()
    {
        moveSpeed = 0;
    }

}
