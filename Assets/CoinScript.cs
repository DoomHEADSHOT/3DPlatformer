using System.Collections;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float soundlength = 0.5f;

    private void Start()
    {
        // Check if the audio source exist
        // the code is fixed here
        if(audioSource == null)
        {
            //add an audiosource 
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoints(5);
            // add sound

            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(soundlength);
        Destroy(gameObject);
    }
}
