using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> windows;

    public Windows defaultWindow;

    public Windows CurrentWindow { get; private set; } //인스펙터에의한 직렬화가 안됨 -> 런타임에서 사용해야함 (??)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        foreach (var window in windows)
        {
            window.Init(this);
            // window.Close();
            window.gameObject.SetActive(false);
        }
        CurrentWindow = defaultWindow;
        windows[(int)CurrentWindow].Open();
    }

    public void Open(Windows id)
    {
        windows[(int)CurrentWindow].Close();
        CurrentWindow = id;
        windows[(int)CurrentWindow].Open();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
