using System.Collections;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private bool isMining = false;
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
            energy.SubtractAmount(1);
        }
    }

    public void OnTap() {
        if (isMining) {
            energy.AddAmount(1);
        }
    }

}
