using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    //WITH AUDIO

    //Bullet Speed, time Between each bullet 
    [SerializeField]
    public float BulletSpeed = 5f;

    [Tooltip("Time unitl next ability to fire shot")]
    public float BulletCoolDown = 1f;
    private float NextFire;

    //Audio Source
    public AudioSource source;

    [HideInInspector]
    public bool canFire = true;

    //Prefab of Bullet
    public GameObject bulletPrefab;
    [Tooltip("Transform location for Bullet to spawn from")]
    public Transform bulletSpawn;

    void Update()
    {


        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

        if (Input.GetButtonUp("Fire1") && canFire && Time.time > NextFire)
        {
            NextFire = Time.time + BulletCoolDown;
            Fire();
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        AudioSource source = GetComponent<AudioSource>();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;

        source.Play();
        Destroy(bullet, 2.0f);
    }
}
