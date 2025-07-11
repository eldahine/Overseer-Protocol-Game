using System.Collections;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private GameObject sunGameObject;
    [SerializeField] private Canvas canvas;

    [SerializeField] private float daytime = 0.5f;
    [SerializeField] private float sign = +1.0f;
    private void Awake()
    {
        UpdateSunPosition();
    }

    private void Update()
    {
        daytime += Time.deltaTime * 60 * sign;

        //if (daytime > canvas.GetComponent<RectTransform>().rect.height * 2) {
        //    sign = -1.0f;
        //}

        //if (daytime < 0)
        //{
        //    sign = 1.0f;
        //}

        UpdateSunPosition();
    }

    private void UpdateSunPosition()
    {
        float angle = daytime / canvas.GetComponent<RectTransform>().rect.height;
        float x = Mathf.Sin(angle) * canvas.GetComponent<RectTransform>().rect.width * 0.5f;
        float y = Mathf.Cos(angle) * canvas.GetComponent<RectTransform>().rect.height * 1.0f;
        Debug.Log(angle);

        sunGameObject.transform.localPosition = new Vector3(x, y, sunGameObject.transform.localPosition.z);
    }

}
