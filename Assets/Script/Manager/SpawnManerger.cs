using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManerger : MonoBehaviour
{
    [SerializeField] Spawner[] spawners;
    [SerializeField] public static SpawnManerger Instance;
    [SerializeField] float lightDistance;
    Spawner nowSpawns;
    bool isSetLight = false;
    int nextSpawnIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowSpawns == null) return;
        
        if (PlayerControl.Instance.IsStart)
        {
            Vector3 playerLoc = PlayerControl.Instance.gameObject.transform.position;
            if (Vector3.Distance(nowSpawns.transform.position, playerLoc) <= nowSpawns.spawnDistance)
            {
                nowSpawns = nowSpawns.Spawn(nextSpawnIndex);
                isSetLight = false;

            }
            else if( !isSetLight && Vector3.Distance(nowSpawns.transform.position, playerLoc) <= lightDistance)
            {
                nextSpawnIndex = Random.Range(0, nowSpawns.dropItem.Length);
                isSetLight = true;
            }
        }
    }

    public void StartSpawn()
    {
        nowSpawns = spawners[0];
    }
}
