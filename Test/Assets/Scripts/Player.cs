using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider2D right_col;
    public Collider2D left_col;

    private Rigidbody2D rigidbody2d;

    private bool jump;

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 3;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        stats.Init();
        right_col.gameObject.SetActive(false);
        left_col.gameObject.SetActive(false);
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
  
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        //if (Input.GetKeyDown("space") && jump == false)
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("jump");
            float jumpVelocity = 3f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            //jump = true;
            //StartCoroutine(WaitJump(1));
        }

        if (Input.GetKeyDown("x"))
        {
            animator.SetTrigger("attack");
            right_col.gameObject.SetActive(true);
            left_col.gameObject.SetActive(true);
            StartCoroutine(WaitAttack(1));
        }

    }

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        Debug.Log(stats.curHealth);
        if (stats.curHealth == 0)
        {
            animator.SetTrigger("death");
        }

    }

    IEnumerator WaitAttack(int sec)
    {
        yield return new WaitForSeconds(sec);
        right_col.gameObject.SetActive(false);
        left_col.gameObject.SetActive(false);
    }

    IEnumerator WaitJump(int sec)
    {
        yield return new WaitForSeconds(sec);
        jump = false;
    }
}
