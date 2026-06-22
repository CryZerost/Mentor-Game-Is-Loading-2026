using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int coinValue;
    public AudioSource audioSource;
    public UnityEvent OnCollect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            player.AddCoinScore(coinValue);
            Destroy(gameObject);

            OnCollect?.Invoke();
        }
    }

    public void CoinSFX(AudioClip namaClip)
    {
        audioSource.PlayOneShot(namaClip);
    }

}
