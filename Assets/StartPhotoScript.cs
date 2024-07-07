using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;using UnityEngine.SceneManagement;

public class StartPhotoScript : MonoBehaviour
{
   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Scenes/StartVideo");
           
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        
    }
}
