using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ProjectileObject = null;
    public GameObject DetonationObject = null;
    
    public float DetonationLifeTime = 1.0f;
    protected float DetonationTime = -1.0f;
    
    protected Vector3 SpawnPosition = new Vector3();
    protected Vector3 AimPosition = new Vector3();
    protected Vector3 AimDirection = new Vector3();

    public float MovementSpeed = 10.0f;
    public virtual void Init(Vector3 aSpawnPosition, Vector3 anAimPosition)
    {
        SpawnPosition = aSpawnPosition;
        AimPosition = anAimPosition;
        AimDirection = AimPosition + SpawnPosition;
        gameObject.transform.LookAt(AimDirection+ SpawnPosition, transform.up);
    }

    public virtual void Start()
    {
        //Debug.Log("I EXIST!");
        ProjectileObject.SetActive(true);
        DetonationObject.SetActive(false);
    }
    public virtual void Update()
    {
        if(DetonationTime > 0)
        {
            DetonationTime -= Time.deltaTime;
            if(DetonationTime < 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Rocket")
        {
            ProjectileObject.SetActive(false);
            DetonationObject.SetActive(true);
            DetonationTime = DetonationLifeTime;
        }
    }
}