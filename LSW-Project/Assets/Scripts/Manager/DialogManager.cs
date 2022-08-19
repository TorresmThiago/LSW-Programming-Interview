using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Transform dialogBox;
    public bool hasActiveDialog;
    public float textSpeed;
    public string[] lines;

    private int _textIndex;

    public void StartDialog()
    {
        _textIndex = 0;
        textComponent.text = string.Empty;
        dialogBox.gameObject.SetActive(true);
        hasActiveDialog = true;
        StartCoroutine(TypeLine());
    }

    public void UpdateDialog()
    {
        if (lines.Length > 0)
        {
            if (dialogBox.gameObject.activeSelf)
            {
                SkipText();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[_textIndex];
            }
        }
    }

    public void NextLine()
    {

        if (_textIndex < lines.Length - 1)
        {
            _textIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _textIndex = 0;
            lines = new string[0];
            dialogBox.gameObject.SetActive(false);
        }
    }

    public void SkipText()
    {
        if (textComponent.text == lines[_textIndex])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[_textIndex];
        }
    }

    public IEnumerator TypeLine()
    {
        foreach (char character in lines[_textIndex].ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);
            textComponent.text += character;
        }
    }
}
