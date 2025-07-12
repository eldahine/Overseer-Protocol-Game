using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float errorCorrectionOffset = 5.0f;
    [SerializeField] private float time;
    [SerializeField] private float timeSpeed = 10.0f;
    [SerializeField] private float direction = -1.0f;


    [SerializeField] private float background2Speed = 1.0f;
    [SerializeField] private float background3Speed = 1.5f;

    [SerializeField] private float background2Offset = 100.0f;
    [SerializeField] private float background3Offset = 200.0f;

    [SerializeField] private RectTransform background2_1;
    [SerializeField] private RectTransform background2_2;
    [SerializeField] private RectTransform background2_3;

    [SerializeField] private RectTransform background3_1;
    [SerializeField] private RectTransform background3_2;
    [SerializeField] private RectTransform background3_3;

    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        
    }

    void Update()
    {
        time += direction * Time.deltaTime * timeSpeed;

        float width = canvas.GetComponent<RectTransform>().rect.width - errorCorrectionOffset;

        float x1 = (time * background2Speed + background2Offset) % width - width;

        background2_1.anchoredPosition = new Vector2(x1, background2_1.position.y);
        background2_2.anchoredPosition = new Vector2(x1 + width, background2_2.position.y);
        background2_3.anchoredPosition = new Vector2(x1 + width + width, background2_3.position.y);

        float x2 = (time * background3Speed + background3Offset) % width - width;

        background3_1.anchoredPosition = new Vector2(x2, background3_1.position.y);
        background3_2.anchoredPosition = new Vector2(x2 + width, background3_2.position.y);
        background3_3.anchoredPosition = new Vector2(x2 + width + width, background3_3.position.y);
    }
}
