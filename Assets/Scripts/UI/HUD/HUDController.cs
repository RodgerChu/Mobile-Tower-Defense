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

    private void Start()
    {
        GameEventObserver.AddHUDHealthEventListener(HUDHealthEvent);
        GameEventObserver.AddOnMOneyChangedListener(OnMoneyChanged);
    }

    private void HUDHealthEvent(uint health)
    {
        currentHealth.text = health.ToString();
    }

    private void OnMoneyChanged(uint newAmount)
    {
        currentMoney.text = newAmount.ToString();
    }
}
