using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject restartButton;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            FindObjectOfType<Timer>().StopTimer();

            loseText.SetActive(true);
            restartButton.SetActive(true);

            audioSource.Play();
        }
    }
}