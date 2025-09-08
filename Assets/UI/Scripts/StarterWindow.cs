using UnityEngine;
using UnityEngine.UI;

public class StarterWindow : GenericWindow
{
    public bool canContinue = true;
    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    protected void Awake()
    {
        continueButton.onClick.AddListener(OnClickContinue); // �������ִ� ���� �����ǰ� �߰��� ����Ǵ°�.
        newGameButton.onClick.AddListener(OnClickContinue);
        optionButton.onClick.AddListener(OnClickContinue); 
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;

        if(continueButton.gameObject.activeSelf) 
            //activeSelf <-> activeHiarachy / activeSelf: �ڱ��ڽ� Ȱ��ȭ���� // activeHiarachy: �θ��� Ȱ��ȭ����
        {

        }
        base.Open();
    }

    public void OnClickContinue()
    {
        Debug.Log("OnClickNewGame");
    }
    public void OnClickNewGame()
    {
        Debug.Log("OnClickNewGame");
    }

    public void OnClickOption()
    {
        Debug.Log("OnClickOption");
    }
}
