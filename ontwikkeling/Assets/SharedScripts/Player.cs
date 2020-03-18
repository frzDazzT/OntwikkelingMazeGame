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
    public GameObject settingsMenu;
    public GameObject dialogCanvas;
    public GameObject dialogManager;

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

        if (!isPaused && !dialogManager.GetComponent<DialogManager>().isDialogOpen)
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
        if (Input.GetButtonDown("Jump") && canJump && !dialogManager.GetComponent<DialogManager>().isDialogOpen && !isPaused)
        {
            canJump = false;
            rb.velocity = new Vector3(0, jumpForce, 0);
            float extraJumpForce = 400f;
            rb.AddForce(transform.forward * extraJumpForce, ForceMode.Force);
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
        if (Input.GetButtonDown("Cancel") && !isPaused )
        {
            pauseMenu.SetActive(true);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<DialogManager>().isDialogOpen = false;
            isPaused = true;
            //stop timer and stop time & show mouse
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameObject.GetComponent<Timer>().pause = true;
        }
        else
        {
            if (Input.GetButtonDown("Cancel") && isPaused)
            {
                UnPause();
            }             
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        isPaused = false;
        //continue timer and time & disable mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.GetComponent<Timer>().pause = false;
    }
}
