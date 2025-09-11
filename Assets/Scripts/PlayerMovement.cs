using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xyspeed = 10;
    public float forwardSpeed = 1f;
    public float lookSpeed ;
    public GameObject aimObject;
    public Transform model;
    public CinemachineSplineCart dollyCart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSpeed(forwardSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        LocalMove(h, v, xyspeed);
        ClampPosition();
        RotationLook(h, v, lookSpeed);
        HorizontalLean(model, h, 110, .1f);

       
    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    void RotationLook(float h, float v, float speed)
    {
        aimObject.transform.parent.position = Vector3.zero;
        aimObject.transform.localPosition = new Vector3(h, v, 1);
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimObject.transform.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis *  leanLimit, lerpTime));
    }

    void SetSpeed(float z)
    {
        var autodolly = dollyCart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
        autodolly.Speed = z;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimObject.transform.position, .5f);
        Gizmos.DrawSphere(aimObject.transform.position, .15f);
    }
}