using Unity.Cinemachine;
using UnityEngine;

public class EnemyMovementActivation : MonoBehaviour
{

    public CinemachineSplineCart enemyCart;
    public float enemyForwardSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SetSpeed(enemyForwardSpeed);
        }
    }

    void SetSpeed(float z)
    {
        var autodolly = enemyCart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
        autodolly.Speed = z;
    }
}
