
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCtrl : ComponentBehavior
{
    [SerializeField] protected Button playAgainBtn;
    [SerializeField] protected Button exitBtn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayAgainBtn();
        this.LoadExitBtn();
    }

    protected virtual void LoadPlayAgainBtn()
    {
        if (playAgainBtn != null) return;
        playAgainBtn = transform.Find("Play Again").GetComponent<Button>();
        if(playAgainBtn != null) Debug.Log(transform.name + " Load PlayAgain Button successful");
    }

    protected virtual void LoadExitBtn()
    {
        if (exitBtn != null) return;
        exitBtn = transform.Find("Exit").GetComponent<Button>();    
        if(exitBtn != null)
            Debug.Log(transform.name + " Load Exit button successful");
    }

    protected override void Start()
    {
        base.Start();
        playAgainBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        exitBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Lobby");
        });
    }
}
