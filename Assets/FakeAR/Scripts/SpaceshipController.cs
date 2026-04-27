using System.Collections;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private float life = 100;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem[] laserbeams;
    private Transform laserObjective;
    private PlayerInfo player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        laserObjective = GameObject.FindGameObjectWithTag("PlayerHead").transform;
        player = FindAnyObjectByType<PlayerInfo>();

        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles += new Vector3(-90, 0, 0);

        for (int i = 0; i < laserbeams.Length; i++) 
        {
            laserbeams[i].transform.LookAt(laserObjective);
        }
    }

    private void Update()
    {
        rb.linearVelocity = transform.up * -speed;
    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackArea"))
        {
            for (int i = 0; i < laserbeams.Length; i++) 
            {
                laserbeams[i].Play();
            }
            StartCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        while (true) 
        {
            player.TakeDamage(damage);
            yield return new WaitForSeconds(0.13f);
        }
    }
}
