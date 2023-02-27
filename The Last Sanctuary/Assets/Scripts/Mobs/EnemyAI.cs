using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    private const int PLAYER_DAMAGE = 2;

    private Transform target;
    private Player player;
    private int currentHp;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<Player>();
        currentHp = maxHP;
    }

    private void Update()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        // Play death animation here
        yield return new WaitForSeconds(1.5f); // or however long the animation takes
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.TakeDamage(PLAYER_DAMAGE);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.TakeDamage(PLAYER_DAMAGE);
        }
    }
}

