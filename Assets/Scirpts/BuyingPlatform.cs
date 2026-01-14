using UnityEngine;

public class BuyingPlatform : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject itemToBuy;
    public float itemCost = 10f;
    private AudioSource audioSource;
    private BoxCollider platformCollider;
    private MeshRenderer platformRenderer;
    public GameObject[] nextBuys;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        platformCollider = GetComponent<BoxCollider>();
        platformRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BuyItem();
        }
    }

    private void BuyItem()
    {
        if (gameManager != null && itemToBuy != null )
        {
            if (gameManager.money - itemCost >= 0)
            {
                audioSource.Play();
                gameManager.SpendMoney(itemCost);
                itemToBuy.SetActive(true);
                foreach (var obj in nextBuys)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                    else
                    {

                    }
                   
                }
                gameManager.RefreshMoneyText();
                platformCollider.enabled = false;
                platformRenderer.enabled = false;
            }
        }
    }
}
