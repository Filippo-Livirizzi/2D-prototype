using UnityEngine;

public class Healt : MonoBehaviour
{
    public int MaxHealth = 3;
    public int currentHealth;
    public HealtUI healtUI;

    void Start()
    {

        currentHealth = MaxHealth;
        healtUI.SetMaxHearts(MaxHealth);
    }


/* private void OnTriggerEnter2D(Collider2D collision)
    {
       Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            //TakeDamage();
        }
    }*/
  /*  private void TakeDamage(int damage)
    {
        currentHealth-= damage;
        healtUI.UpdateHearts(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }*/

}
