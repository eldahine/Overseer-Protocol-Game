using System.Collections;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private bool isMining = true;
    [SerializeField] private bool isLifeSupport = true;
    private Energy energy;
    private Welfare welfare;


    private void Awake()
    {
        energy = GetComponent<Energy>();
        welfare = GetComponent<Welfare>();
    }

    private void Start()
    {
        StartCoroutine(TimerCountDown());
    }

    IEnumerator TimerCountDown() {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (isMining) {
                energy.SubtractAmount(1);
            }

            if (!isLifeSupport) {
                welfare.SubtractAmount(1);
            }

        }
    }

    public void OnTap() {
        var amount = 0;

        if (isMining && !isLifeSupport) {
            amount = 2;
        }

        if (!isMining && isLifeSupport)
        {
            amount = 2;
        }

        if (isMining && isLifeSupport)
        {
            amount = 1;
        }

        if (isMining) {
            energy.AddAmount(amount);
        }

        if (isLifeSupport && welfare.GetAmount() < 100)
        {
            welfare.AddAmount(amount);
        }
    }

    public void ToggleMiningMode()
    {
        isMining = !isMining;
    }

    public void ToggleLifeSupport()
    {
        isLifeSupport = !isLifeSupport;
    }


}
