using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Camera cam;
    public float moveSpeed = 4;
    public float jumpForce = 3;
    Vector3 moveDir;
    bool canJump = true;
    [HideInInspector]
    public bool isPaused = false;

    public GameObject pauseMenu;

    public bool level1Key, level2Key, level3Key;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        //movement
        // rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime) +
        //     (transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime));

        if (!isPaused)
        {
            moveDir.x = Input.GetAxis("Horizontal");
            moveDir.z = Input.GetAxis("Vertical");

            transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
        }       
    }

    private void Update()
    {
        Pause();

        //jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
            rb.AddForce(transform.forward * 50f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    void Pause()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            //stop timer and stop time & show mouse
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            if (Input.GetButtonDown("Cancel") && isPaused)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                //continue timer and time & disable mouse
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;               
                Time.timeScale = 1f;
            }             
        }
    }
}
