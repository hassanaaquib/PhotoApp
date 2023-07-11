using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    
   public void LevelChange()
    {
        PlayerPrefs.SetInt("Index", 0);
        SceneManager.LoadScene(1);
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.Quit();
            }
        }
    }
}
