using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCH : MonoBehaviour
{
    //ĳ���� Ŭ��
    public GameObject targetObject;
    public Text dialogText;
    public SmoothCamera smoothCamera;
    public DialogManager dialogManager;
    public GameObject Dialog ;
    bool SetActiveDialog = false;
    //private List<string> list = new List<string>();
    void Start()
    {
        //list.Add("�ȳ�");
        //list.Add("�ɳ�");
        //list.Add("�ɳɳĳ�");

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

            //��� �������
            //int randomIndex = Random.Range(0, list.Count);
            //string selectedDialogue = list[randomIndex];

            // Ray�� Ư�� ������Ʈ�� �浹�ߴ��� �˻��մϴ�.
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject)
            {
                // Ư�� ������Ʈ�� Ŭ���Ǿ��� ���� ������ �ۼ��մϴ�.
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
