using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public Transform dialogBox;

    public string[] _lines;
    private int _textIndex;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == _lines[_textIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = _lines[_textIndex];
            }
        }
    }

    public void StartDialog(string path)
    {
        if (!dialogBox.gameObject.activeSelf)
        {
            _textIndex = 0;
            _lines = System.IO.File.ReadAllLines(path);
            textComponent.text = string.Empty;
            dialogBox.gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }
    }

    public void NextLine()
    {
        if (_textIndex < _lines.Length - 1)
        {
            _textIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _textIndex = 0;
            _lines = null;
            dialogBox.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char character in _lines[_textIndex].ToCharArray())
        {
            textComponent.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
