using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("AudioSource")]
    [SerializeField] AudioSource moneyGetAudioSource;
    [SerializeField] AudioSource eggGetAudioSource;
    [SerializeField] AudioSource breadGetAudioSource;
    [SerializeField] AudioSource throwAudioSource;
    [SerializeField] AudioSource hpIncreaseAudioSource;
    [SerializeField] AudioSource openBagAudioSource;
    [SerializeField] AudioSource openWindowAudioSource;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource walkAudioSource;
    [SerializeField] AudioSource humenHitAudioSource;
    [SerializeField] AudioMixer audioMixer;
    
    [Header("AudioClip")]
    [SerializeField] AudioClip moneyGetAudioClip;
    [SerializeField] AudioClip eggGetAudioClip;
    [SerializeField] AudioClip breadGetAudioClip;
    [SerializeField] AudioClip throwAudioClip;
    [SerializeField] AudioClip hpIncreaseAudioClip;
    [SerializeField] AudioClip openBagAudioClip;
    [SerializeField] AudioClip openWindowAudioClip;
    [SerializeField] AudioClip[] humenHitAudioClip;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

    }

    public void PlayMoneyGetAudio()
    {
        moneyGetAudioSource.PlayOneShot(moneyGetAudioClip);
    }    
    public void PlayEggGetAudio()
    {
        eggGetAudioSource.PlayOneShot(eggGetAudioClip);
        humenHitAudioSource.PlayOneShot(humenHitAudioClip[Random.Range(0,humenHitAudioClip.Length)]);
    }    
    public void PlayBreadGetAudio()
    {
        breadGetAudioSource.PlayOneShot(breadGetAudioClip);
        hpIncreaseAudioSource.PlayOneShot(hpIncreaseAudioClip);
    }

    public void PlayThrowAudio()
    {
        throwAudioSource.PlayOneShot(throwAudioClip);
    }
    
    public void OpenBagAudio()
    {
        openBagAudioSource.PlayOneShot(openBagAudioClip);
    }
    
    public void OpenWindowAudio()
    {
        openWindowAudioSource.PlayOneShot(openWindowAudioClip);
    }
    
    public void PlayBGM()
    {
        bgmAudioSource.Play();
        walkAudioSource.Play();
    }
    
    public void StopBGM()
    {
        bgmAudioSource.Stop();
        walkAudioSource.Stop();

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }

    public bool IsMute()
    {
        audioMixer.GetFloat("Master",out float val);
        return (val <= -49) ? true : false;
    }
    
}
