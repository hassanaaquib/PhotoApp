using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPlacement : MonoBehaviour
{

    [SerializeField] GameObject[] photoFrames;
    [SerializeField] GameObject objReference;
    [SerializeField] int speed;


    int indexValue;

    public void CallStart()
    {
        indexValue = PlayerPrefs.GetInt("Index");
        Debug.Log("IndexValue" + indexValue);

        StartCoroutine(LoadImage());

        StartCoroutine(Move());
    }

    IEnumerator LoadImage()
    {

        for (int i = 0; i < indexValue; i++)
        {
            Texture2D tex = new Texture2D(16, 16);
            tex.LoadImage(File.ReadAllBytes(Application.persistentDataPath + "/" + i + ".png"));
            tex.Apply();
            photoFrames[i].GetComponentInChildren<RawImage>().texture = tex;
            yield return new WaitForSeconds(.3f);
        }
        
    }

    IEnumerator Move()
    {
        while (true)
        {
            if(transform.position == objReference.transform.position)
            {
                yield return new WaitForSeconds(1f);
                break;
            }
            gameObject.transform.position = Vector3.MoveTowards(transform.position, objReference.transform.position, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.04f);
        }
        while (true)
        {
            if (transform.position == photoFrames[PlayerPrefs.GetInt("Index")].transform.position)
            {
                Debug.LogWarning("dfghjkl");
                break;
            }

            gameObject.transform.position = Vector3.MoveTowards(transform.position, photoFrames[PlayerPrefs.GetInt("Index")].transform.position, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.007f);
        }
        
        
        //==========================================================================
        indexValue = PlayerPrefs.GetInt("Index");
        indexValue += 1;
        if (indexValue > 2)
        {
            indexValue = 0;
        }
        PlayerPrefs.SetInt("Index", indexValue);
        Debug.Log(PlayerPrefs.GetInt("Index"));

    }
    
}
