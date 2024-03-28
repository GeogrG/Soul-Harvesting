using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float verticalSpeed;
    [SerializeField] Transform attackingPoint;
    [SerializeField] float radius = 1f;
    [SerializeField] Slider slider;
    public LayerMask soulsLayers;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Flip();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attacking");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackingPoint.position, radius, soulsLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<SoulScript>().KillCharacket();
                slider.value += enemy.GetComponent<SoulScript>().GetPoints();
            }
        }
    }

    private void Flip()
    {
        bool isHavingXSpeed = Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon;
        bool isHavingSpeed = Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("Vertical")) > Mathf.Epsilon;
        anim.SetBool("Speed", isHavingSpeed);
        if (isHavingXSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")), 1f);
        }
    }

    private void Move()
    {
        var inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var newXPos = transform.position.x + inputX;
        var inputY = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        var newYPos = transform.position.y + inputY;
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }
}
