using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private GameObject sunGameObject;
    [SerializeField] private GameObject moonGameObject;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private string dayTextPrefix;


    [SerializeField] private Canvas canvas;

    [SerializeField] private float daytime = 0.0f;
    private void Awake()
    {
        UpdateSunPosition();
        UpdateMoonPosition();
    }

    private void Update()
    {
        daytime += Time.deltaTime * 60;
        dayText.text = dayTextPrefix + ((daytime - 1800) / (3600 * 2) + 1).ToString("0");

        UpdateSunPosition();
        UpdateMoonPosition();
    }

    private void UpdateSunPosition()
    {
        float angle = (daytime - 1800) / canvas.GetComponent<RectTransform>().rect.height;
        float x = Mathf.Sin(angle) * canvas.GetComponent<RectTransform>().rect.width * 0.5f;
        float y = Mathf.Cos(angle) * canvas.GetComponent<RectTransform>().rect.height * 1.0f;
        sunGameObject.transform.localPosition = new Vector3(x, y, sunGameObject.transform.localPosition.z);
    }

    private void UpdateMoonPosition()
    {
        float angle = (daytime + 1800) / canvas.GetComponent<RectTransform>().rect.height;
        float x = Mathf.Sin(angle) * canvas.GetComponent<RectTransform>().rect.width * 0.5f;
        float y = Mathf.Cos(angle) * canvas.GetComponent<RectTransform>().rect.height * 1.0f;
        moonGameObject.transform.localPosition = new Vector3(x, y, moonGameObject.transform.localPosition.z);
    }

}
