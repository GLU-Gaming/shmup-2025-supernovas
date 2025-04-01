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
        score = Mathf.Clamp(score, 0, 2147483647);
        scoreText.text = "Score: " + score;
    }
}
