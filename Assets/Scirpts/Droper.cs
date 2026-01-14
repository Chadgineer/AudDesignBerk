using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Droper : MonoBehaviour
{
    public GameObject item1;
    private Vector3 dropPoint;
    [SerializeField] private float droprate = 1f;
    private AudioSource audioSource;

    private void Awake()
    {
        dropPoint = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(DropRoutine());
    }
    private void DropItem()
    {
        Instantiate(item1, dropPoint, Quaternion.identity);
        audioSource.Play();
    }

    IEnumerator DropRoutine()
    {
        while (true)
        {
            DropItem();
            yield return new WaitForSeconds(2f / droprate);
        }
    }
}
