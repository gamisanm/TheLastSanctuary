using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 100;
    public int currentHp;
    public float moveSpeed = 5;
    public Slider HPslider;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousPos;

    private void Start()
    {
        currentHp = maxHP;
        HPslider.maxValue = maxHP;
        HPslider.value = currentHp;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        HPslider.value = currentHp;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
