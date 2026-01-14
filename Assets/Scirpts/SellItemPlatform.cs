using UnityEngine;

public class SellItemPlatform : MonoBehaviour
{
    public LayerMask sellableLayers;
    private GameManager gameManager;
    private AudioSource audioSource;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((sellableLayers.value & (1 << collision.gameObject.layer)) > 0)
        {
            audioSource.Play();
            float sellValue = new float();
            sellValue = collision.gameObject.GetComponent<SellableItem>().currentSellValue;
            gameManager.AddUncollectedMoney(sellValue);
            Destroy(collision.gameObject);
        }
    }

}
