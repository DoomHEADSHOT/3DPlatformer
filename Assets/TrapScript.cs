using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoints(-5);
            Destroy(gameObject);
        }
    }
}
