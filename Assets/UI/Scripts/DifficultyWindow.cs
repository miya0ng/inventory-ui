using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class DifficultyWindow : GenericWindow
{

    public int index;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    //public override void Open()
    //{
    //    base.Open();
    //    SaveLoadManager.Load();
    //    index = SaveLoadManager.Data.difficulty;
    //    toggles[index].isOn = true;
    //}

    public void OnToggle()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
           if(toggles[i].isOn)
            {

                Debug.Log(i);
                break;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnClickEasy(bool value)
    {
        if (value)
        {
            index = 0;
            Debug.Log("OnClickEasy");
        }
    }
    public void OnClickNormal(bool value)
    {
        if (value)
        {
            index = 1;
            Debug.Log("OnClickNormal");

        }
    }
    public void OnClickHard(bool value)
    {
        if (value)
        {
            index = 2;
            Debug.Log("OnClickHard");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Open()
    {
        base.Open();
        SaveLoadManager.Load();
        index = SaveLoadManager.Data.difficulty;
        toggles[index].isOn = true;
        toggles[index].Select();
    }
    public override void Close()
    {
        base.Close();
        SaveLoadManager.Data.difficulty = index;
        toggles[index].isOn = true;
        toggles[index].Select();
        SaveLoadManager.Save();
    }

}
