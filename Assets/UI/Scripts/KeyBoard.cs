using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : GenericWindow
{
    //public List<Button> inputKeys = new List<Button>();
    public GameObject keyGroup;
    public Button[] Keys;
    public TextMeshProUGUI inputField;
    public string underBar = "_";
    public Button Cancel;
    public Button Accect;
    public Button Delete;
    private bool isUnderBar = true;
    private Coroutine barCoroutine;
    private static readonly int maxInputLength = 7;


    void Start()
    {
        Cancel.onClick.AddListener(() => OnCancle());
        Accect.onClick.AddListener(() => OnAccect());
        Delete.onClick.AddListener(() => OnDelete());
        barCoroutine = StartCoroutine(UnderBarBlink());
        Keys = keyGroup.GetComponentsInChildren<Button>();

        for (int i = 0; i < Keys.Length; i++)
        {
            int index = i;
            Keys[i].onClick.AddListener(() => OnClickKey(index)
           );
        }
    }

    private void Update()
    {

    }

    private IEnumerator UnderBarBlink()
    {
        while(true)
        {
            inputField.text += "_";

            yield return new WaitForSeconds(0.5f);

            inputField.text = inputField.text.Replace("_", string.Empty);


            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnClickKey(int index)
    {
        if (inputField.text.Length <= maxInputLength)
        {
            string key = Keys[index].GetComponentInChildren<TextMeshProUGUI>().text.Replace("\n", "");
            inputField.text += key;


            //inputField.text = sb.ToString();
            Debug.Log("keyclick");
        }
    }
    public void OnCancle()
    {
        var text = inputField.text.Remove(inputField.text.Length - 1);
        inputField.text = text;
    }

    public void OnAccect()
    {
        base.Close();
        Close();
    }
    public void OnDelete()
    {
        Debug.Log("Delete button clicked!");
        inputField.text = string.Empty;
    }
}