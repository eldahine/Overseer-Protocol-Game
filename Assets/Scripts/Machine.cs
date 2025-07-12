using System.Collections;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;

    [SerializeField] private bool isMining = true;
    [SerializeField] private bool isLifeSupport = true;
    private Energy energy;
    private LifeSupport lifesupport;
    private Drill drill;
    private FuelCrystal fuelCrystal;

    [SerializeField] private Animator drillAnimator;

    private void Awake()
    {
        energy = GetComponent<Energy>();
        lifesupport = GetComponent<LifeSupport>();
        drill = GetComponent<Drill>();
        fuelCrystal = GetComponent<FuelCrystal>();
        audioSource = GetComponent<AudioSource>();
        ChangeAudioClip(0);
    }

    private void Start()
    {
        StartCoroutine(TimerCountDown());
    }

    IEnumerator TimerCountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (isMining && UsePower(5))
            {
                drill.AddAmount(5);
                fuelCrystal.AddAmount(drill.GetAmount() / 5);
            }
            else
            {
                drill.SubtractAmount(25);
            }

            if (isLifeSupport && UsePower(1))
            {
                lifesupport.AddAmount(1);
            }
            else
            {
                lifesupport.SubtractAmount(1);
            }

            // natural energy decapitation
            UsePower(1);


            if (lifesupport.GetAmount() < 1) {
                // the machine has completly died, so does the crew, show game over panel
                GameOver();
            }
        }
    }

    private void GameOver() {
        if (gameOverPanel.activeSelf == false)
        {
            ChangeAudioClip(1);
        }
        gameOverPanel.SetActive(true);
    }

    public void ChangeAudioClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[clipIndex]; 
            audioSource.Play();
        }
    }

    private bool UsePower(long amount)
    {
        if (energy.GetAmount() > 0)
        {
            energy.SubtractAmount(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTap()
    {
        if (fuelCrystal.GetAmount() > 0)
        {
            energy.AddAmount(1);
            fuelCrystal.SubtractAmount(1);
        }
    }

    public void ToggleMiningMode()
    {
        isMining = !isMining;

        drillAnimator.SetBool("isMining", isMining);
    }

    public void ToggleLifeSupport()
    {
        isLifeSupport = !isLifeSupport;
    }

}
