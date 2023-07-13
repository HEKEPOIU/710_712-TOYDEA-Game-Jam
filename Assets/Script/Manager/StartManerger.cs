using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManerger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        if (GameManager.Instance)
        {
            GameManager.IsPlay = false;
            GameManager.Instance.ResetGameValue();
        }
        SceneManager.LoadScene("Content");
    }
    
}
