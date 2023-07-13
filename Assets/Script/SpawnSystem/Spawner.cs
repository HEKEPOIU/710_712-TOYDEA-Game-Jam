using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float spawnDistance = 10f;
    public GameObject[] dropItem;
    Animator animator;
    int whichItem = 0;
    static readonly int Open = Animator.StringToHash("Open");
    [SerializeField] Spawner nextSpawner;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float addSpeed = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public Spawner Spawn(int which)
    {

        whichItem = which;
        animator.speed += (GameManager.Instance.Score / 10f) * addSpeed;
        animator.SetBool(Open,true);
        return nextSpawner;
    }

    public void ThrowItem()
    {
        GameObject item = Instantiate(dropItem[whichItem], spawnPoint.position, Quaternion.identity);
        item.GetComponent<DropItem>().AddSpeed((GameManager.Instance.Score / 10f) * GameManager.Instance.AddSpeed);
    }

    public void Close()
    {
        animator.SetBool(Open,false);
    }

    public void OpenWindow()
    {
        AudioManager.Instance.OpenWindowAudio();
    }
    
}
