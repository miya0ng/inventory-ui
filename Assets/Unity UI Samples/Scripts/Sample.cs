using UnityEngine;

public class Sample : MonoBehaviour
{
    public Transform panel;
    public Transform scrollView;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            panel.SetAsLastSibling(); // 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scrollView.SetAsLastSibling(); // 
        }
    }
}
