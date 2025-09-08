using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class DifficultyWindow : GenericWindow
{

    public int index = 0;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public override void Open()
    {
        base.Open();
        toggles[index].isOn = true;
        index = SaveLoadManager.Data.difficulty;
        SaveLoadManager.Load();
    }

    public void OnToggle()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
           if(toggles[i].isOn)
            {
                index = i;
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
            Debug.Log("OnClickEasy");
        }
    }
    public void OnClickNormal(bool value)
    {
        if (value)
        {
            Debug.Log("OnClickNormal");

        }
    }
    public void OnClickHard(bool value)
    {
        if (value)
        {
            Debug.Log("OnClickHard");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        SaveLoadManager.Data.difficulty = index;
        SaveLoadManager.Save();
    }

}
