using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public GameObject attackArea;
  public Animator animator;

  private bool canAttack = true; //controlla il flusso di gioco. La variabile obbliga la fine dell'animazione per iniziare la prossima.
  public float attackCooldown = 0.4f; //tempo minimo tra 2 attacchi
  

  void start(){
    animator = GetComponent <Animator>();
  }

  void update(){
    if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
    StartAttack();

    }

  void StartAttack(){

    canAttack = false;
    //attackArea.SetActive(true);

    animator.SetTrigger("isAttack");

    Debug.Log("Player: Attacco eseguito e animazione avviata");
    Invoke("ResetAttackCooldown", attackCooldown);
  }

  void ResetAttackCooldown(){
    canAttack = true;
  }

    public void ActivateAttackCollider(){
        attackArea.SetActive(true);
        Debug.Log("!!! Collider Attivato dagli Eventi!!!");
    }

    public void DeactivateAttackCollider(){
        attackArea.SetActive(false);
        Debug.Log("!!! COLLIDER DISATTIVATO DAGLI EVENTI !!!");
    }

}
