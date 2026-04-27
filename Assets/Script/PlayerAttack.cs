using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float attackCooldown = 0.5f;
    private float lastAttackTime;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        TryAttack();
        
    }

    void TryAttack(){
        if (Time.time < lastAttackTime + attackCooldown)
            return;

            lastAttackTime = Time.time;
            animator.SetTrigger("isAttack");
    }
}
