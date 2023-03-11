using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCH : MonoBehaviour
{
    //캐릭터 클릭
    public GameObject targetObject;
    public Text dialogText;
    public SmoothCamera smoothCamera;
    public DialogManager dialogManager;
    public GameObject Dialog ;
    bool SetActiveDialog = false;
    //private List<string> list = new List<string>();
    void Start()
    {
        //list.Add("안녕");
        //list.Add("냥냥");
        //list.Add("냥냥냐냥");

        smoothCamera.isActivated = false;
        dialogManager.isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //대사 랜덤출력
            //int randomIndex = Random.Range(0, list.Count);
            //string selectedDialogue = list[randomIndex];

            // Ray가 특정 오브젝트와 충돌했는지 검사합니다.
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject)
            {
                // 특정 오브젝트가 클릭되었을 때의 동작을 작성합니다.
                //dialogText.text = selectedDialogue.ToString();
                smoothCamera.isActivated = true;
                SetActiveDialog = false;
                Invoke("DialogPlay", 2);
            }
            
        }

        
    }

   

    void DialogPlay()
    {
        Dialog.SetActive(true);
        dialogManager.isRunning = true;
    }

}
