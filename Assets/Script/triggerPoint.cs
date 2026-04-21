using UnityEngine;

public class triggerPoint : MonoBehaviour
{

    public Enemy enemyScript;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            enemyScript.StartChasing();
            GetComponent<Collider2D>().enabled = false; // Disable the trigger to prevent multiple activations
        }
    }
}
