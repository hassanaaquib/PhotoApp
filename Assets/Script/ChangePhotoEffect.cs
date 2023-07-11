using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhotoEffect : MonoBehaviour
{
    [SerializeField] List<GameObject> UI = new List<GameObject>();

    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;

    [SerializeField] int currentIndexValue;


    void Start()
    {
        for (int i = 0; i < UI.Count; i++)
        {
            UI[i].SetActive(false);
        }
        UI[0].SetActive(true);
        currentIndexValue = 0;


        rightButton.SetActive(true);
        leftButton.SetActive(false);

    }



    public void RightButton()
    {
        if (currentIndexValue < UI.Count - 1)
        {
            leftButton.SetActive(true);
            UI[currentIndexValue].SetActive(false);
            currentIndexValue++;
            UI[currentIndexValue].SetActive(true);
        }
        if (currentIndexValue == UI.Count - 1)
        {
            rightButton.SetActive(false);
        }

    }

    public void LeftButton()
    {
        if (currentIndexValue >= 1)
        {
            rightButton.SetActive(true);
            UI[currentIndexValue].SetActive(false);
            currentIndexValue--;
            UI[currentIndexValue].SetActive(true);
        }
        if (currentIndexValue == 0)
        {
            leftButton.SetActive(false);
        }

    }
}
