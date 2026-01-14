using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyPlatform : MonoBehaviour
{
    public GameManager gameManager;
    private int cooldown = 2;
    private bool onCooldown = false;
    private Material platformMaterial;
    private AudioSource audioSource;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        platformMaterial = GetComponent<Renderer>().material;
        platformMaterial.color = Color.green;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!onCooldown && gameManager.unCollectedMoney > 0)
            {
                Debug.Log("Money Collected");
                audioSource.Play();
                gameManager.CollectMoney();
                StartCoroutine(CooldownCoroutine());
            }
        }
    }

    IEnumerator CooldownCoroutine()
    {
        onCooldown = true;
        platformMaterial.color = Color.red; 
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
        platformMaterial.color = Color.green;
    }
}