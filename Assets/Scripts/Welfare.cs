using TMPro;
using UnityEngine;

public class Welfare : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private long count;
    [SerializeField] private string prefixString;

    void Awake()
    {
        UpdateUI();
    }
    void OnValidate()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        textMeshProUGUI.text = prefixString + count.ToString();
    }

    public void AddAmount(long amount)
    {
        count += amount;
        UpdateUI();
    }

    public void SubtractAmount(long amount)
    {
        count -= amount;
        UpdateUI();
    }
}
