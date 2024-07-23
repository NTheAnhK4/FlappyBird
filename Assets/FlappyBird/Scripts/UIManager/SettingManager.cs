
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : ComponentBehavior
{
    [SerializeField] protected Button settingBtn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (settingBtn != null) return;
        settingBtn = transform.GetComponentInChildren<Button>();
        Debug.Log(transform.name + " Load Setting Button successful");
    }

    protected override void Start()
    {
        settingBtn.onClick.AddListener(DisplaySettingMenu);
    }
    

    protected void DisplaySettingMenu()
    {
        Time.timeScale = 0f;
        Debug.Log("Display menu");
    }
}
