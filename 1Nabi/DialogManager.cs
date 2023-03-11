using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string filePath; // CSV 파일 경로
    // 대화 데이터를 저장할 리스트
    public List<Dialog> dialogs = new List<Dialog>();

    public Text characterNameText; // 캐릭터 이름을 출력할 UI 텍스트
    public Text dialogText; // 대사를 출력할 UI 텍스트
    public GameObject button;
    public float typingSpeed; // 대사가 서서히 출력되는 속도
    public bool isRunning = true;


    private int currentDialogIndex = 0; // 현재 출력 중인 대화 인덱스
    private bool isTyping = false; // 대사 출력 중인지 여부

    void Start()
    {
        LoadDialogsFromCSV();
        DisplayDialog();
        button.SetActive(false);
    }

    void LoadDialogsFromCSV()
    {
        string[] lines = File.ReadAllLines(filePath); // CSV 파일 읽기

        for (int i = 1; i < lines.Length; i++) // 첫 번째 줄은 헤더이므로 무시하고 두 번째 줄부터 데이터를 읽음
        {
            string[] fields = lines[i].Split(','); // 쉼표로 구분된 값들을 배열로 읽어옴
            Dialog dialog = new Dialog(fields[0], fields[1]); // 캐릭터 이름과 대사를 Dialog 클래스에 저장
            dialogs.Add(dialog); // 대화 데이터를 리스트에 추가
        }
    }

    void DisplayDialog()
    {
        if (currentDialogIndex >= dialogs.Count) // 대화가 끝났으면 함수를 종료, 버튼 활성화
        {
            button.SetActive(true);
            return;
        }

        Dialog dialog = dialogs[currentDialogIndex]; // 출력할 대화 가져오기
        characterNameText.text = dialog.characterName; // 캐릭터 이름 출력
        

        // 대사 출력 함수 호출
        StartCoroutine(TypeDialogText(dialog.text));
    }

    // 대사가 서서히 출력되는 코루틴
    IEnumerator TypeDialogText(string text)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char c in text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    // 다음 대화로 넘어가는 함수
    public void NextDialog()
    {
        // 대사 출력 중일 때는 클릭이 무시되도록 함
        if (isTyping)
        {
            return;
        }

        // 다음 대화로 이동
        currentDialogIndex++;

        // 대화 출력 함수 호출
        DisplayDialog();
    }

    void Update()
    {
        if (isRunning && Input.GetMouseButtonDown(0))
        {
            NextDialog();
        }

        if (isRunning && Input.GetKeyDown(KeyCode.Space))
        {
            NextDialog();
        }
    }
}

public class Dialog
{
    public string characterName; // 캐릭터 이름
    public string text; // 대사

    public Dialog(string characterName, string text)
    {
        this.characterName = characterName;
        this.text = text;
    }
}