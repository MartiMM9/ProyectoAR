using UnityEngine;
using UnityEngine.UI;

public class PrefabImageTracking : MonoBehaviour
{
    [SerializeField] private float maxLife;
    [SerializeField] private float actualLife;
    [SerializeField] private float damage;
    private Animator animator;
    private PrefabImageTracking objective;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Image lifeBar;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        canvasTransform.LookAt(Camera.main.transform.position);
        if (objective != null) 
        {
            transform.LookAt(objective.transform.position);
        }
    }

    public void TakeDamage(float _damage)
    {
        actualLife -= _damage;
        if (actualLife <= 0) 
        {
            actualLife = 0;
            animator.SetBool("isAttacking", false);
            animator.SetTrigger("Death");
            objective.Win();
        }
        UpdateLife(actualLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fighter"))
        {
            objective = other.GetComponent<PrefabImageTracking>();
            animator.SetBool("isAttacking", true);
        }
    }

    public void Attack()
    {
        objective.TakeDamage(damage);
    }

    public void Win()
    {
        animator.SetBool("isAttacking", false);
        animator.SetTrigger("Win");
    }

    private void UpdateLife(float _actualLife)
    {
        lifeBar.fillAmount = _actualLife / maxLife;
    }
}
