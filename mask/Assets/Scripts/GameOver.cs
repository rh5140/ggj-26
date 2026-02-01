using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalMessage; 
    [SerializeField] GameTimer gameTimer;

    void Awake()
    {
        finalMessage.text = "You survived for " + gameTimer.GetFormattedTime() + " at the office.";
    }

}
