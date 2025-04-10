using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image livesImg;

    void Start()
    {
        playerHealth.EntityDamaged += UpdateUi;
        UpdateUi();
    }

    void UpdateUi()
    {
        livesImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,40*playerHealth.currentHealth);
    }
}
