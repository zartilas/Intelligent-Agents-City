using TMPro;
using UnityEngine;

public class GetText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI npcWinner;

    GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = gameObject.AddComponent<GameOver>();

        npcWinner = GameObject.Find("NPCNAME").GetComponent<TextMeshProUGUI>();
        string text = gameOver.TextWinner.text;
        npcWinner.SetText(text.ToString());
        Debug.Log(text);
    }
}
