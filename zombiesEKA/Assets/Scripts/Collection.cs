using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{
    public static int Skull = 0;
    public TextMeshProUGUI skullText;

    [SerializeField] private AudioClip collectSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Skull++;
            skullText.text = "Skull: " + Skull.ToString();

            audioSource.PlayOneShot(collectSound);

            Destroy(other.gameObject);
        }
    }
}