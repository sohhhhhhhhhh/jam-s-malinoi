using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float _timer = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= 1 * Time.deltaTime;
        if (_timer < 0)
        {
            SceneManager.LoadScene("GameStart");
        }
    }
}
