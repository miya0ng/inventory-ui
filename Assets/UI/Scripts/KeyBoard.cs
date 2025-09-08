using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : GenericWindow
{
    //public List<Button> inputKeys = new List<Button>();
    public GameObject KEYS;
    public TextMeshProUGUI inputField;
    public Button Cancel;
    public Button Accect;
    public Button Delete;
    private bool isUnderBar = true;
    private Coroutine barCoroutine;
    private static readonly int maxInputLength = 7;


    private void UpdateUnderbar()
    {
        if (barCoroutine != null)
        {
            StopCoroutine(barCoroutine);
        }
        barCoroutine = StartCoroutine(updateBar());
    }
    public override void Open()
    {
        base.Open();
        inputField.text = string.Empty;
        isUnderBar = true;
        UpdateUnderbar();
    }

    private void Awake()
    {
        var ikeys = KEYS.GetComponentsInChildren<Button>();
        foreach (var key in ikeys)
        {
            key.onClick.AddListener(() => OnKeyPress(key));
        }
        //foreach (var key in inputKeys)
        //{
        //    key.onClick.AddListener(() => OnKeyPress(key));
        //}
        Cancel.onClick.AddListener(OnCancel);
        Accect.onClick.AddListener(OnAccect);
        Delete.onClick.AddListener(OnDelete);

    }

    public IEnumerator updateBar()
    {
        while (isUnderBar)
        {
            inputField.text = "_";
            yield return new WaitForSeconds(0.5f);
            inputField.text = string.Empty;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnKeyPress(Button key)
    {
        if (inputField.text.Length >= maxInputLength)
        {
            return;
        }
        isUnderBar = false;
        inputField.text = string.Concat(inputField.text, key.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    public void OnDelete()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }
        if (inputField.text.Length <= 0)
        {
            inputField.text = string.Empty;
            isUnderBar = true;
            UpdateUnderbar();
        }
    }
    public void OnCancel()
    {
        inputField.text = string.Empty;
        isUnderBar = true;
        UpdateUnderbar();
    }
    public void OnAccect()
    {
        gameObject.SetActive(false);
    }
}