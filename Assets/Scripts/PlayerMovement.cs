    using System;
using TTDemoScripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float health = 100;

    public CharacterController controller;
    //public SimpleSmoothMouseLook test;
    //Variable Parameters
    public float sprintSpeed = 24f;
    public float normalSpeed = 12f;
    public float gravity = -9.81f;
    //Incode Use Parameters
    private float speed = 12f;
    private bool isGrounded = false;
    private Boolean sprintEnabled = false;
    private Text speedTextObject;
    public GameObject healtbarparent;
    public GameObject DeadPanel;

    Vector3 velocity;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //speedTextObject = GameObject.Find("SpeedText").GetComponent<Text>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            //Destroy(transform.gameObject);
            animator.SetBool("isDead", true);
            animator.Play("Death");
            DeadPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            try
            {
                GameObject bar = GameObject.Find("Bar");
                bar.transform.localScale = new Vector3((health) / 100, 1);
            }
            catch (Exception e)
            {

            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            if (controller.isGrounded)//Rigidbody collision �zelli�i yerine kullan�l�yor.
            {
                velocity.y = 0f;
                isGrounded = true;
            }

            if (isShiftKeyDown)
            {
                sprint(true);
            }
            else
            {
                sprint(false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
                //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            var velocity2 = Vector3.forward * Input.GetAxis("Vertical") * speed;
            if (speedTextObject != null)
            {
                speedTextObject.text = (velocity2.magnitude * Time.deltaTime).ToString();
            }
            try
            {
                animator.SetFloat("Speed", (velocity2.magnitude * Time.deltaTime) * 10);

            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.name.ToString() + "   <------ ");
        Debug.Log(other.tag + "   <------ ");


    }

    private void OnTriggerStay(Collider test)
    {

        Debug.Log(test.name.ToString() + "   <------ ");
        Debug.Log(test.tag + "   <------ ");

    }

    //TO-DO Rigid Body test edildikten sonra a�a��daki kodlar incelenecek.
    /* private void OnCollisionStay(Collision collision)
     {
         Debug.Log("Collission stay");
         isGrounded = true;
         velocity.y = 0f;
     }

     private void OnCollisionExit(Collision collision)
     {
         Debug.Log("Collission exit");
     }*/
    void sprint(bool enabled)
    {
        if (enabled && !sprintEnabled)
        {
            speed = sprintSpeed;
        }
        else if (sprintEnabled && !enabled)
        {
            speed = normalSpeed;
        }
        sprintEnabled = enabled;
    }
    public void Jump()
    {
        //Debug.Log("test");
        velocity.y = 4f;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Die()
    {
        Debug.Log("Kullanıcı öldü");
    }
    public void takeDamage(float damage)
    {
        //Debug.Log(damage + "hasar alındı");
        health -= damage;
        if(health > 100)
        {
            health = 100;
        }
    }

}
