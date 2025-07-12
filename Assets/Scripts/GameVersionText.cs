using TMPro;
using UnityEngine;

public class GameVersionText : MonoBehaviour
{
    [SerializeField] private string suffix = "+GameZanga13 Edition";
    [SerializeField] private string prefix = "v";

    void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = prefix + Application.version + suffix;
    }

}
