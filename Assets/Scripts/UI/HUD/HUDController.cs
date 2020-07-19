using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    
    public TextMeshProUGUI currentMoney;
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI currentWave;

    private uint wave = 1;
    private uint maxWaves = 2;
    private void Awake()
    {
        GameEventObserver.AddHUDHealthEventListener(HUDHealthEvent);
        GameEventObserver.AddOnMOneyChangedListener(OnMoneyChanged);
        GameEventObserver.AddHUDMaxWaveEventListener(OnMaxWaveChanged);
    }

    private void HUDHealthEvent(uint health)
    {
        currentHealth.text = health.ToString();
    }

    private void OnMoneyChanged(uint newAmount)
    {
        currentMoney.text = newAmount.ToString();
    }

    public void OnWaveComplete()
    {
        wave++;
        if (wave > maxWaves)
        {
            wave = maxWaves;
        }

        UpdateWaveText();
    }

    public void OnMaxWaveChanged(uint newMaxWaves)
    {
        maxWaves = newMaxWaves;
        UpdateWaveText();
    }

    private void UpdateWaveText()
    {
        currentWave.text = wave.ToString() + "/" + maxWaves.ToString();
    }
}
