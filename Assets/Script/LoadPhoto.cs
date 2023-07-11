using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadPhoto : MonoBehaviour
{
    PhotoPlacement photoPlacement;

    void Start()
    {
        photoPlacement = FindAnyObjectByType<PhotoPlacement>();
        StartCoroutine(PhotoLoad());
    }

    IEnumerator PhotoLoad()
    {
        Texture2D tex = new Texture2D(16, 16);
        tex.LoadImage(File.ReadAllBytes(Application.persistentDataPath + "/" + PlayerPrefs.GetInt("Index") + ".png"));
        tex.Apply();

        gameObject.GetComponent<RawImage>().texture = tex;

        yield return new WaitForSeconds(0.5f);

        photoPlacement.CallStart();

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}
