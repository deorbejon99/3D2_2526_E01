using DG.Tweening;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputSystem_Actions inputActions ;
    public float xyspeed = 10;
    public float forwardSpeed = 1f;
    public float lookSpeed ;
    public GameObject aimObject;
    public Transform model;
    public CinemachineSplineCart dollyCart;
    public AudioSource audioSource;
    public TrailRenderer leftTrail, rightTrail;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

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

    private void OnEnable()
    {
        inputActions.Player.Boost.performed += OnBoostPressed;
        inputActions.Player.Boost.canceled += OnBoostReleased;
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Player.Boost.performed -= OnBoostPressed;
        inputActions.Player.Boost.canceled -= OnBoostReleased;
        inputActions.Disable();
    }

    void OnBoostPressed(InputAction.CallbackContext context)
    {
        Boost(true);
    }

    void OnBoostReleased(InputAction.CallbackContext context)
    {
        Boost(false);
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
    public void QuickSpin(int dir)
    {
        if(!DOTween.IsTweening(model))
        {
            model.DOLocalRotate(new Vector3(model.localEulerAngles.x, model.localEulerAngles.y, 360 * dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);

        }
    }


    public void Boost(bool state)
    {

        if (state)
        {
            audioSource.Play();

        }
        else
        {
            audioSource.Stop();
        }

        leftTrail.emitting = state;
        rightTrail.emitting = state;




            float speed = state ? forwardSpeed * 2 : forwardSpeed;

        DOVirtual.Float(forwardSpeed, speed, .15f, SetSpeed);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimObject.transform.position, .5f);
        Gizmos.DrawSphere(aimObject.transform.position, .15f);
    }
}