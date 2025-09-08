using System.Collections;
using System.Text;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameOverWindow : GenericWindow
{
    public Button Next;
    public TextMeshProUGUI LeftStats;
    public TextMeshProUGUI LeftScore;

    private int randomScore = 0;
    private Coroutine coroutine;

    private void Awake()
    {
        Next.onClick.AddListener(OnClickStartScene);
    }

    public override void Open()
    {
        LeftStats.text += string.Empty;
        LeftScore.text += string.Empty;

        if(coroutine != null )//@
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CoShowText());
        //StopCoroutine();
        //StopAllCoroutine(); -> scene에있는 모든 코루틴 정지시킴
    }
    public IEnumerator CoShowText()
    {
         for(int i = 0; i < 3; i++)
        {
            randomScore = Random.Range(0, 99);
            //LeftStats.keyText += "STATS\n";
            //LeftScore.keyText += "00\n";
            StringBuilder stats = new StringBuilder();
            StringBuilder score = new StringBuilder();
            stats.Append(LeftStats.text);
            stats.Append("STATS\n");
            score.Append(LeftScore.text);
            score.Append(randomScore);

            yield return new WaitForSeconds(1f);
        }
        coroutine = null;
    }
    public void OnClickStartScene()
    {

    }
}
