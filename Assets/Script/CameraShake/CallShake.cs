using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CallShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource shakeSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayOpenBagMusic()
    {
        AudioManager.Instance.OpenBagAudio();
    }
    
    void Shake()
    {
        shakeSource.GenerateImpulse();
    }
}
