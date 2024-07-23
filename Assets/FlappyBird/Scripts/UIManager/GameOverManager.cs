using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : ComponentBehavior
{
    
    protected override void Awake()
    {
        base.Awake();
        this.AddListener(EventID.On_Player_Dead, param=>GameOver());
    }

    protected virtual void GameOver()
    {
        Time.timeScale = 0;
        transform.Find("GameOver").gameObject.SetActive(true);
    }
}
