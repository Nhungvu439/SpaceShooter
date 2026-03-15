using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;

    public System.Action OnDead;
    public System.Action OnHealthChanged;   

    private int healthPoint;

    private void Start()
    {
        healthPoint = defaultHealthPoint;
        OnHealthChanged?.Invoke();          
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        OnHealthChanged?.Invoke();          

        if (healthPoint <= 0)
            Die();
    }

    protected virtual void Die()
    {
        var explosion = Instantiate(
            explosionPrefab,
            transform.position,
            transform.rotation
        );

        Destroy(explosion, 1);
        Destroy(gameObject);

        OnDead?.Invoke();
    }
}