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
        continueButton.onClick.AddListener(OnClickContinue); // 기존에있는 것은 유지되고 추가로 연결되는것.
        newGameButton.onClick.AddListener(OnClickContinue);
        optionButton.onClick.AddListener(OnClickContinue); 
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;

        if(continueButton.gameObject.activeSelf) 
            //activeSelf <-> activeHiarachy / activeSelf: 자기자신 활성화여부 // activeHiarachy: 부모의 활성화여부
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
