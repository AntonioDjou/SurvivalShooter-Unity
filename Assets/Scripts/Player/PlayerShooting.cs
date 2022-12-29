using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 10;
    public float range = 100f;
 
    public Camera fpsCam;
    public GameObject Arrow;
    AudioSource playerAudio;                     // References the arrow shot audio.

    int shootableMask; // A layer mask so the raycast only hits things on the shootable layer.

    void Awake()
    {
        shootableMask = LayerMask.GetMask ("Shootable"); // Create a layer mask for the Shootable layer.
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        playerAudio.Play();
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, shootableMask))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent <EnemyHealth> (); //What been hit is going to acess the EnemyHealth Script.
            if(enemyHealth != null) // If the target's health is not null
            {
                enemyHealth.TakeDamage (damagePerShot, hit.point); // Take the damage per shot.
            }
            //GameObject impactGO = Instantiate (Arrow, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject obj = ObjectPooler.current.GetPooledObject(); // References the static current from the ObjectPooler Script
            if(obj == null) //Check to see if the returned GameObject from the Pool is null
            {
                return; 
            }

            obj.SetActive(true); 
            obj.transform.position = hit.point;
            obj.transform.rotation = Quaternion.LookRotation(hit.normal);
            //Destroy(impactGO, 2f);
        }
    }

    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }


}