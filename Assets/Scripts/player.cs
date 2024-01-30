using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject panel, particle, weapon;
    public AudioSource audioSource;
    public AudioClip jumpAudio, takeCoinAudio;

    public float jumpForce, movingSeped;
    Vector3 move;

    public TextMeshProUGUI txtScore;
    int score = 0;

    bool isCanJump = false, isDead = false, isLeftBtnDown = false, isRightBtnDown = false;

    //Canh giai quyet cong kenh va tam thoi
    public void LeftBtnDown()
    {
        isLeftBtnDown = true;
        isRightBtnDown = false;
    }

    public void RightBtnDown()
    {
        isLeftBtnDown = false;
        isRightBtnDown = true;
    }

    public void BtnUp()
    {
        isLeftBtnDown = false;
        isRightBtnDown = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(takeCoinAudio);
            Destroy(other.gameObject);
            score++;
            txtScore.SetText(score.ToString());
        }
        if (other.gameObject.tag == "Flag")
        {
            score += 100;
            txtScore.SetText(score.ToString());
            nextLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isCanJump = true;
            animator.SetBool("jump", false);
        }
        if (other.gameObject.tag == "Spike" || other.gameObject.tag == "Enemy")
        {
            dead();
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(particle, transform);
        //Instantiate(weapon, transform);
        move = new Vector3(movingSeped, 0, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftBtnDown) moveLeft();
        else if (isRightBtnDown) moveRight();
        else idle();
    }

    public void dead()
    {
        animator.SetBool("dead", true);
        animator.SetBool("run", false);
        animator.SetBool("jump", false);
    }

    public void idle()
    {
        animator.SetBool("idle", true);
        animator.SetBool("run", false);
    }

    public void jump()
    {
        if (isCanJump)
        {
            audioSource.PlayOneShot(jumpAudio);
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isCanJump = false;
            animator.SetBool("jump", true);
        }
    }

    public void moveLeft()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.Translate(-move);
        animator.SetBool("idle", false);
        animator.SetBool("run", true);
    }

    public void moveRight()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        transform.Translate(move);
        animator.SetBool("idle", false);
        animator.SetBool("run", true);
    }

    public void nextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
            SceneManager.LoadScene("Level 2");
        if (SceneManager.GetActiveScene().name == "Level 2")
            SceneManager.LoadScene("Thank you");
    }
}
