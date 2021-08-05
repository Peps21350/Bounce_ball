using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMecanics : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager gm;
    public GeneratingObject go;



    //public AudioSource audioSource;

    public static int money;
    public Text textMoney;


    public float SpeedRun = 350f;
    public float SpeedToLeft = 40f;
    public float SpeedToRight = 40f;
    public float JumpForce = 3.5f;
    public bool isGrounded;

    //private bool runForward = false;
    //private bool runRevers = false;
    public bool GodMode = false;
    private bool strafeRight = false;
    private bool strafeLeft = false;
    private bool jump = false;



    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle" && GodMode == false)
        {
            gm.EndGame();
        }

        if (collision.collider.tag == "Finish")
        {
            SavePrefs.moneyToSave = money;
            gm.Finish();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            isGrounded = false;
            money += 1;
        }
        
    }




    void Update()
    {
        if (Input.GetKey("escape"))
        {
            gm.Pause();
        }

        textMoney.text = money.ToString();

        if (Input.GetKey("p"))
        {
            GodMode = !GodMode;
        }


        if (Input.GetKey("d"))
        {
            strafeRight = true; // вправо
        }
        else { strafeRight = false; }

        if (Input.GetKey("a"))
        {
            strafeLeft = true; // вліво 
        }
        else { strafeLeft = false; }

        if (Input.GetKey("space"))
        {
            jump = true;
            //audioSource.Play();
        }

        if (transform.position.y < -3f && GodMode == false)
        {
            gm.EndGame();
        }
    }

    private void FixedUpdate()
    {

        rb.AddForce(0,0,Time.deltaTime * SpeedRun);

        if (strafeRight)
        {
            rb.AddForce(Time.deltaTime * SpeedToLeft, 0, 0, ForceMode.VelocityChange);
        }

        if (strafeLeft)
        {
            rb.AddForce(Time.deltaTime * -SpeedToLeft,0,0, ForceMode.VelocityChange);
        }

        if (jump && isGrounded)
        {
            rb.AddForce(new Vector3 (0,1.5f * JumpForce,0), ForceMode.Impulse);
            jump = false;
        }
    }
}
