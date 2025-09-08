using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class GenericWindow : MonoBehaviour
{
    public GameObject firstSelected;
    protected WindowManager manager;

    public void Init(WindowManager mgr)
    { 
        manager = mgr;
    }
    public void OnFocus()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
            // 이 부분을 실행할 때 eventsystem 가지고있는 component 탐색해서 가져옴.
            // 비슷하게 Camera.main -> 지금실행하고 있는 씬에 메인카메라에 있는 카메라 컴포넌트 탐색해서 호출함.
            // EventSystem.current.SetSelectedGameObject(gameObject)-> 셀렉트 상태로 바꿔주는 애.
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
