using UnityEngine;

public class EnemyTest : MonoBehaviour
{

    private void OnTriggerEnter2d(Collision2D collider){
        if(collider.gameObject.CompareTag("PlayerAttack")){
            Debug.Log("Nemico: Sono stato Colpito");
        }
    }
}
