using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject uiPause;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }
    }

public void PauseToggle()
    {
        if (!isPaused)
        {
            print("Game terkena pause");
            if (!uiPause.activeSelf)
            {
                uiPause.SetActive(true);
            }
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            print("Game dilanjutkan");
            if (uiPause.activeSelf)
            {
                uiPause.SetActive(false);
            }
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
