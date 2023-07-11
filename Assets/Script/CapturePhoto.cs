using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CapturePhoto : MonoBehaviour
{

    [SerializeField] GameObject cameraClick;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;

    [SerializeField] Animator sceneTransition;
    [SerializeField] Animator CountDown;


    public void CaptureScreenShot()
    {
        CountDown.SetBool("CountDown", true);

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3.0f);
        sceneTransition.SetBool("Transition", true);

        yield return new WaitForSeconds(.8f);


        cameraClick.SetActive(false);
        rightButton.SetActive(false);
        leftButton.SetActive(false);

        yield return new WaitForSeconds(0.2f);


#if PLATFORM_ANDROID
        ScreenCapture.CaptureScreenshot("/" + PlayerPrefs.GetInt("Index") + ".png"); // for android
#endif
#if UNITY_EDITOR || UNITY_EDITOR_WIN
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/"+ PlayerPrefs.GetInt("Index") + ".png");// for desktop PC
#endif

        yield return new WaitForSeconds(0.2f);
       

        SceneManager.LoadScene(2);
    }


  
}
   