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

    public void StartDialog(string path)
    {
        if (!dialogBox.gameObject.activeSelf)
        {
            _textIndex = 0;
            _lines = System.IO.File.ReadAllLines(path);

            dialogBox.gameObject.SetActive(true);
            textComponent.text = string.Empty;

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

    public void SkipText()
    {
        if (dialogBox.gameObject.activeSelf)
        {
            if (textComponent.text == _lines[_textIndex])
            {
                NextLine();
            }
            else
            {
                textComponent.text = _lines[_textIndex];
                StopAllCoroutines();
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char character in _lines[_textIndex].ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);
            textComponent.text += character;
        }
    }
}
