using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private bool jumpStop = true;
    
    
    void Start()
    {
        speed = 10;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        
        //Jump Sequence
        if (Input.GetKeyDown("space") && jumpStop)
        {
            jumpStop = false;
            for (int i = 0; i < 30; i++)
            {
                rb.AddForce(0, i, 0);
            }

          // if (rb.velocity.y == 0)
            {
                jumpStop = true;
            }
            
        }


        //Death
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce (movement * speed);
        //print(SceneManager.GetActiveScene().buildIndex);
    }

    //Collission Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinCube"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex +1);
        }
    }



}
