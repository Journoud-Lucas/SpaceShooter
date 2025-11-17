using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject chargedProjectilePrefab;
    [SerializeField] float fireRate = 0.3f;
    [SerializeField] float chargeTime = 2f;

    private float fireTimer = 0f;
    private float chargeTimer = 0f;
    private bool isCharging = false;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            isCharging = true;
            chargeTimer += Time.deltaTime;
        }
        else if (isCharging)
        {
            if (chargeTimer >= chargeTime && chargedProjectilePrefab != null)
            {
                Instantiate(chargedProjectilePrefab, transform.position, Quaternion.identity);
            }
            else if (fireTimer >= fireRate && projectilePrefab != null)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                fireTimer = 0f;
            }

            chargeTimer = 0f;
            isCharging = false;
        }
    }
}
