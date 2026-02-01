using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Singleton
    public static PlayerShooting instance;

    [Header("Bullet Settings")]
    public GameObject bulletPrefabs;
    public float shootingInterval;
    public Vector3 bulletOffset;

    [Header("Weapon Power")]
    public int weaponPower = 1;
    public int maxweaponPower = 5;

    private float lastBulletTime;

    private void Awake()
    {
        // Singleton setup
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    private void ShootBullet()
    {
        // Bắn nhiều đạn theo weaponPower
        for (int i = 0; i < weaponPower; i++)
        {
            Instantiate(
                bulletPrefabs,
                transform.position + bulletOffset,
                transform.rotation
            );
        }
    }
}
