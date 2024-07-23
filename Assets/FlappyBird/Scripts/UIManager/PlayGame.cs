using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : ComponentBehavior
{
    [SerializeField] protected Button playGameBtn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }

    protected void LoadButton()
    {
        if (playGameBtn != null) return;
        playGameBtn = transform.GetComponent<Button>();
        if(playGameBtn != null)
            Debug.Log(transform.name + " Load Player button successful");
    }

    protected override void Start()
    {
        base.Start();
        playGameBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("InGame");
        });
    }
}
