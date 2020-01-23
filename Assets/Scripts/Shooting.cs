
using UnityEngine;

public class Shooting : Bolt.EntityBehaviour<ICustomCubeState>
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject muzzle;

    public override void Attached()
    {
        state.OnShoot = Shoot;
    }

    private void Shoot()
    {
        GameObject bulletCloneGO = Instantiate(bulletPrefab, muzzle.transform.position, this.transform.rotation);
        Rigidbody bulletClone = bulletCloneGO.GetComponent<Rigidbody>();
        bulletClone.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && entity.IsOwner)
        {
            state.Shoot(); // Calling callback function
        }        

    }

    
}
