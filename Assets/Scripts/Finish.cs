using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string sceneName;
    public int targetPoint = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (targetPoint != Player.instance.coinScore)
            {
                print("poin belum terkumpul");
            }
            else
            {
                Player.instance.ResetCoin();
                SceneManager.LoadScene(sceneName);
            }
            
        }
    }
}
