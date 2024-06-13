using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TitleUIManager : MonoBehaviour
{
    public GameObject[] HomeBtn = new GameObject[3];

    public GameObject Guide;

    public GameObject[] Pages = new GameObject[5];
    public GameObject[] PageBtn = new GameObject[2];

    public VideoClip[] EnemyVideoClip = new VideoClip[3];
    public GameObject EnemyVideoPlayer;

    int currentPage = 0;

    private void Start()
    {
        currentPage = 0;
        InitGuideObj();

        Guide.SetActive(false);
    }

    public void ClickPlayBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickGuideBtn()
    {
        ActivateHomeBtn(false);
        Guide.SetActive(true);
        InitGuideObj();
    }

    public void ClickExitBtn()
    {
        Application.Quit();
    }


    void InitGuideObj()
    {
        for (int i = 0; i < Pages.Length; i++)
            Pages[i].SetActive(false);

        Pages[0].SetActive(true);
        InitPageBtn();
    }

    public void ClickCloseGuide()
    {
        Guide.SetActive(false);
        ActivateHomeBtn(true);
    }

    public void ClickNextPage()
    {
        Pages[currentPage].SetActive(false);
        SetPageBtn(1);
        Pages[currentPage].SetActive(true);
        SetEnemyVideoClip();
    }

    public void ClickPreviousPage()
    {
        Pages[currentPage].SetActive(false);
        SetPageBtn(-1);
        Pages[currentPage].SetActive(true);
        SetEnemyVideoClip();
    }

    void InitPageBtn()
    {
        PageBtn[0].SetActive(false);
        PageBtn[0].SetActive(true);
    }

    void SetPageBtn(int value)
    {
        if (value == 1)
            currentPage += 1;
        else
            currentPage -= 1;


        if (currentPage == 0)
        {
            PageBtn[0].SetActive(false);
            PageBtn[1].SetActive(true);
        }
        else if(currentPage == 4)
        {
            PageBtn[0].SetActive(true);
            PageBtn[1].SetActive(false);
        }
        else
        {
            PageBtn[0].SetActive(true);
            PageBtn[1].SetActive(true);
        }
    }
    
    void ActivateHomeBtn(bool value)
    {
        for(int i=0; i<HomeBtn.Length; i++)
            HomeBtn[i].SetActive(value);
    }

    void SetEnemyVideoClip()
    {
        int tmpPage = currentPage - 2;
        if (currentPage >= 2)
            EnemyVideoPlayer.GetComponent<VideoPlayer>().clip = EnemyVideoClip[tmpPage];
    }

}
