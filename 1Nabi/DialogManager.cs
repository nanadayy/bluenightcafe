using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string filePath; // CSV ���� ���
    // ��ȭ �����͸� ������ ����Ʈ
    public List<Dialog> dialogs = new List<Dialog>();

    public Text characterNameText; // ĳ���� �̸��� ����� UI �ؽ�Ʈ
    public Text dialogText; // ��縦 ����� UI �ؽ�Ʈ
    public GameObject button;
    public float typingSpeed; // ��簡 ������ ��µǴ� �ӵ�
    public bool isRunning = true;


    private int currentDialogIndex = 0; // ���� ��� ���� ��ȭ �ε���
    private bool isTyping = false; // ��� ��� ������ ����

    void Start()
    {
        LoadDialogsFromCSV();
        DisplayDialog();
        button.SetActive(false);
    }

    void LoadDialogsFromCSV()
    {
        string[] lines = File.ReadAllLines(filePath); // CSV ���� �б�

        for (int i = 1; i < lines.Length; i++) // ù ��° ���� ����̹Ƿ� �����ϰ� �� ��° �ٺ��� �����͸� ����
        {
            string[] fields = lines[i].Split(','); // ��ǥ�� ���е� ������ �迭�� �о��
            Dialog dialog = new Dialog(fields[0], fields[1]); // ĳ���� �̸��� ��縦 Dialog Ŭ������ ����
            dialogs.Add(dialog); // ��ȭ �����͸� ����Ʈ�� �߰�
        }
    }

    void DisplayDialog()
    {
        if (currentDialogIndex >= dialogs.Count) // ��ȭ�� �������� �Լ��� ����, ��ư Ȱ��ȭ
        {
            button.SetActive(true);
            return;
        }

        Dialog dialog = dialogs[currentDialogIndex]; // ����� ��ȭ ��������
        characterNameText.text = dialog.characterName; // ĳ���� �̸� ���
        

        // ��� ��� �Լ� ȣ��
        StartCoroutine(TypeDialogText(dialog.text));
    }

    // ��簡 ������ ��µǴ� �ڷ�ƾ
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

    // ���� ��ȭ�� �Ѿ�� �Լ�
    public void NextDialog()
    {
        // ��� ��� ���� ���� Ŭ���� ���õǵ��� ��
        if (isTyping)
        {
            return;
        }

        // ���� ��ȭ�� �̵�
        currentDialogIndex++;

        // ��ȭ ��� �Լ� ȣ��
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
    public string characterName; // ĳ���� �̸�
    public string text; // ���

    public Dialog(string characterName, string text)
    {
        this.characterName = characterName;
        this.text = text;
    }
}