using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI scoreText;
    int score;
    void Start()
    {
        score = 0;
        scoreText.text = "Score" + score;
    }
    public void UiUpdate(int amount)
    {
        score = score + amount;
        score = Mathf.Clamp(score, 0, 2147483647);
        scoreText.text = "Score" + score;
    }
}
