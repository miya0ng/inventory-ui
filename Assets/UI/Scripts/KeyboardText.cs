using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class KeyboardText : MonoBehaviour
{
    public TextMeshProUGUI Text { get; set; }

    private bool isblink;
    public bool isText;
    private float timer;
    //private TextMeshProUGUI keyText;
    private void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        //button = GetComponent<Button>();
        //keyText = GetComponent<TextMeshProUGUI>();
        //button.onClick.AddListener(Onclick);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            isblink = true;
            timer = 0;
        }

        if (isblink)
        {
            Text.text = " ";
            isblink = false;
        }
        else if (timer > 0)
        {
            Text.text = "_";
        }
        else if (Text.text != "_" && Text.text != " ")
        {
            isblink = false;
        }

    }
}
