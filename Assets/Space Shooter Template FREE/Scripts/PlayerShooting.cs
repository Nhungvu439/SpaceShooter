using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Singleton để Bonus.cs gọi được
    public static PlayerShooting instance;

    public GameObject bulletPrefabs;

    public float shootingInterval = 0.2f;
    private float lastBulletTime;

    public int weaponPower = 1;       // số đạn hiện tại
    public int maxweaponPower = 3;    // số đạn tối đa

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime > shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        for (int i = 0; i < weaponPower; i++)
        {
            Instantiate(
                bulletPrefabs,
                transform.position,
                transform.rotation
            );
        }
    }
}
