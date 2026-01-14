using UnityEngine;

public class SellableItem : MonoBehaviour
{
     public float currentSellValue = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ValueIncreaser"))
        {
            currentSellValue *= 2f;
        }
    }
}
