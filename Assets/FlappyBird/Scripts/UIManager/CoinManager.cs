using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : ComponentBehavior
{
    [SerializeField] protected TextMeshProUGUI coinText;
    private int currentCoin;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCoinText();
    }

    protected virtual void LoadCoinText()
    {
        if (coinText != null) return;
        coinText = transform.GetComponentInChildren<TextMeshProUGUI>();
        if(coinText != null)
            Debug.Log(transform.name + " Load Coin Text successful");
    }

    protected override void Awake()
    {
        base.Awake();
        this.currentCoin = 0;
        this.AddListener(EventID.On_Player_Gain_Coin,param => AddCoin((int)param));
    }

    protected virtual void AddCoin(int num)
    {
        currentCoin += num;
        coinText.text = currentCoin.ToString();
    }
}
