using TMPro;
using UnityEngine;

public class FuelCrystal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private long count;
    [SerializeField] private long max;
    [SerializeField] private long min;
    [SerializeField] private string prefixString;
    [SerializeField] private string suffixString;

    void Awake()
    {
        UpdateUI();
    }

    void OnValidate()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        textMeshProUGUI.text = prefixString + count.ToString() + suffixString + max;
    }

    public void AddAmount(long amount) { 
        count += amount;

        if (count > max) {
            count = max;
        }

        UpdateUI();
    }

    public void SubtractAmount(long amount)
    {
        count -= amount;

        if (count < min)
        {
            count = min;
        }

        UpdateUI();
    }

    public long GetAmount()
    {
        return count;
    }
}
