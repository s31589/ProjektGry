using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;
    [SerializeField] private Transform spawnPoint;

    private Animator anim;
    private bool _isDead = false;
    public bool isDead => _isDead; // publiczny getter, ale prywatne ustawianie

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Jeśli postać spadnie za mapę i nie jest martwa
        if (transform.position.y < -10f && !_isDead)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if (_isDead) return;

        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;

        if (anim != null)
        {
            anim.SetBool("isDead", true);
            anim.SetTrigger("IsDead");
        }

        StartCoroutine(WaitAndRespawn());
    }

    private IEnumerator WaitAndRespawn()
    {
        yield return new WaitForSeconds(2.5f); // czas na animację śmierci

        Respawn();
    }

    private void Respawn()
    {
        health = maxHealth;
        _isDead = false;

        // Przenieś postać na punkt odrodzenia
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }

        // Zresetuj animacje
        if (anim != null)
        {
            anim.SetBool("isDead", false);
            anim.ResetTrigger("IsDead");
            anim.Play("Idle"); // Upewnij się, że masz stan "Idle" w Animatorze
        }
    }
}
