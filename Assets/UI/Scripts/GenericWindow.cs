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
            // �� �κ��� ������ �� eventsystem �������ִ� component Ž���ؼ� ������.
            // ����ϰ� Camera.main -> ���ݽ����ϰ� �ִ� ���� ����ī�޶� �ִ� ī�޶� ������Ʈ Ž���ؼ� ȣ����.
            // EventSystem.current.SetSelectedGameObject(gameObject)-> ����Ʈ ���·� �ٲ��ִ� ��.
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
