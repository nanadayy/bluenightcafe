using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public GameObject button;
    public Image image;
    public Image optionimage;

    void Start()
    {
        image.enabled = false;
        optionimage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Start
    public void StartScene() //씬 변경 메소드 // public으로 선언해야 ui에 넣을 수 있습니다
    {
        button.SetActive(false); //버튼 비활성화
        image.enabled = true; // Fade 이미지 활성화 Fade in out 구현
        StartCoroutine(Fade()); //코루틴으로 시간 딜레이
        Invoke("Scene", 2f);
       
      
    }

    IEnumerator Fade()
    {
        float fadeCount = 0;
        while(fadeCount < 1.1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 마다 실행
            image.color = new Color(0, 0, 0, fadeCount);
            if(fadeCount == 1f)
            {
                break;
            }
        }

        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 마다 실행
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }

    void Scene()
    {
        SceneManager.LoadScene("ListScene");
    }

    //option
    public void Option()
    {
        optionimage.enabled = true;
        StartCoroutine(Fade2());
    }

    IEnumerator Fade2()
    {
        float fadeCount = 0;
        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초 마다 실행
            optionimage.color = new Color(47f / 255f, 79f / 255f, 108f / 255f, fadeCount);
           
        }
    }
  
    //Exit
    public void Exit()
    {
        Application.Quit();
    }
    
}
