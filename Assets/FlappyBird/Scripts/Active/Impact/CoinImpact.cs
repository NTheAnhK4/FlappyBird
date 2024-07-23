using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImpact : ComponentBehavior
{
    [SerializeField] protected AudioSource gainCoin;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSound();
    }

    protected virtual void LoadSound()
    {
        if (gainCoin != null) return;
        gainCoin = transform.GetComponentInChildren<AudioSource>();
        Debug.Log(transform.name + " Load sound successful");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            this.PostEvent(EventID.On_Player_Gain_Coin,1);
            gainCoin.Play();
            CoinSpawner.Instance.DespawnObject(transform);
        }
      
    }
}
