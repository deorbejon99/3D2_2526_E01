using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public Transform bulletOrigin2;

    public AudioSource shootSound;


    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)

        { 
        GameObject newBullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
        GameObject newBullet2 = Instantiate(bulletPrefab, bulletOrigin2.position, Quaternion.identity);
        newBullet.transform.forward = gameObject.transform.forward;
        newBullet2.transform.forward = gameObject.transform.forward;

        shootSound.pitch = Random.Range(.6f, 1f);
        shootSound.Play();
        }


    }



}
