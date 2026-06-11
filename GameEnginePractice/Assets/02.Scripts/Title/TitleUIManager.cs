using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] HomeBtn = new GameObject[3];

    [SerializeField] private GameObject Guide;

    [SerializeField] private GameObject[] Pages = new GameObject[5];
    [SerializeField] private GameObject[] PageBtn = new GameObject[2];

    [SerializeField] private VideoClip[] EnemyVideoClip = new VideoClip[3];
    [SerializeField] private GameObject EnemyVideoPlayer;

    private int currentPage = 0;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentPage = 0;
        InitGuideObj();

        Guide.SetActive(false);
    }

    public void ClickPlayBtn()
    {
        PlayAudio();
        SceneManager.LoadScene("Main");
    }

    public void ClickGuideBtn()
    {
        PlayAudio();
        ActivateHomeBtn(false);
        Guide.SetActive(true);
        InitGuideObj();
    }

    public void ClickExitBtn()
    {
        PlayAudio();
        Application.Quit();
    }


    private void InitGuideObj()
    {
        for (int i = 0; i < Pages.Length; i++)
            Pages[i].SetActive(false);

        Pages[0].SetActive(true);
        InitPageBtn();
    }

    public void ClickCloseGuide()
    {
        PlayAudio();
        Guide.SetActive(false);
        ActivateHomeBtn(true);
    }

    public void ClickNextPage()
    {
        PlayAudio();
        Pages[currentPage].SetActive(false);
        SetPageBtn(1);
        Pages[currentPage].SetActive(true);
        SetEnemyVideoClip();
    }

    public void ClickPreviousPage()
    {
        PlayAudio();
        Pages[currentPage].SetActive(false);
        SetPageBtn(-1);
        Pages[currentPage].SetActive(true);
        SetEnemyVideoClip();
    }

    private void InitPageBtn()
    {
        PageBtn[0].SetActive(false);
        PageBtn[1].SetActive(true);
    }

    private void SetPageBtn(int value)
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
    
    private void ActivateHomeBtn(bool value)
    {
        for(int i=0; i<HomeBtn.Length; i++)
            HomeBtn[i].SetActive(value);
    }

    private void SetEnemyVideoClip()
    {
        int tmpPage = currentPage - 2;
        if (currentPage >= 2)
        {
            EnemyVideoPlayer.GetComponent<VideoPlayer>().clip = EnemyVideoClip[tmpPage];
            EnemyVideoPlayer.GetComponent<VideoPlayer>().Play();
        } 
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }
}
