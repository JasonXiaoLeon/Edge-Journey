using UnityEngine;

public class InputControl : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField]
    private GameObject UI;
    // Update is called once per frame
    void Update()
    {
        // 如果按下 Esc 键，暂停或继续游戏
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UI.SetActive(true);
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // 暂停游戏
    void PauseGame()
    {
        Time.timeScale = 0f; // 将游戏时间暂停
    }

    // 继续游戏
    public void ResumeGame()
    {
        Time.timeScale = 1f; // 恢复正常游戏时间流逝
        isPaused = false;
        UI.SetActive(false);
    }

    // 退出游戏
    public void Exit()
    {
        Application.Quit();
    }
}
