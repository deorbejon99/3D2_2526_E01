using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;

    public float attackRange;
    public float attackRate;
   
    public GameObject bullet;
    public Transform bulletOrigin;

    private bool isPlayerInAttackRange;
    public LayerMask whatIsPlayer;

    private void Update()
    {
        isPlayerInAttackRange = Physics.CheckSphere(gameObject.transform.position, attackRange, whatIsPlayer);

        if(isPlayerInAttackRange )
        {
            AttackPlayer();
        }

    }

    void AttackPlayer()
    {
        FaceTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - gameObject.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
