using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelPlayerManager : ComponentBehavior
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected TextMeshProUGUI expText;
    [SerializeField] protected float curExp;
    [SerializeField] protected float maxExp;
    [SerializeField] protected int playerLevel = 1;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
        this.LoadExpText();
    }

    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + " Load Silder successful");
    }

    protected virtual void LoadExpText()
    {
        if (expText != null) return;
        expText = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + " Load expText successful");
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetEXP();
        this.ResetSliderInfor();
    }

    protected virtual void ResetEXP()
    {
        this.curExp = 0;
        this.maxExp = 4;
    }
    protected virtual void ResetSliderInfor()
    {
       
        this.slider.minValue = 0;
        this.slider.maxValue = maxExp;
        this.slider.value = curExp;
    }

    protected override void Awake()
    {
        base.Awake();
        this.AddListener(EventID.On_Player_Add_EXP,param=>AddExp((float)param));
    }

    protected virtual void AddExp(float add)
    {
        curExp += add;
        if (curExp >= maxExp)
        {
            curExp -= maxExp;
            maxExp *= 2;
            this.ResetSliderInfor();
            AddLevel();
            
        }
        this.slider.value = curExp;

    }

    protected virtual void AddLevel()
    {
        playerLevel++;
        this.expText.text = "Level : " + playerLevel.ToString();
        this.PostEvent(EventID.On_Player_Level_Change, playerLevel);
    }
}
