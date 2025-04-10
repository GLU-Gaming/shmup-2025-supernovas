using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI scoreText;
    int score;
    void Start()
    {
        score = 0;
        UiUpdate(0);
    }
    public void UiUpdate(int amount)
    {
        score = score + amount;
        string numberString = score.ToString();
        string scoreString = "Score: ";
        for (int i = 0; i < 5 - numberString.Length; i++)
        {
            scoreString += 0;
        }
        scoreString += numberString;
        scoreText.text = scoreString;
    }
}