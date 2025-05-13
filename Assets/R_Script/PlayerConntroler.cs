using System.Collections;
using UnityEngine;

public class PlayerConntroler : MonoBehaviour
{
    public GameObject poweupIndicator;
    float powerUpStre = 15.5f;
    private GameObject focalPoint;
    private Rigidbody playerrRb;
    public float speed = 5.0f;
    public bool isOnTouch;
    void Start()
    {
        playerrRb = GetComponent<Rigidbody>();  
        focalPoint = GameObject.Find("Focal Point");
        
   
    }

    void Update()
    {
        if (playerrRb == null || focalPoint == null) return; 

        float forwordInput = Input.GetAxis("Vertical");
        playerrRb.AddForce(focalPoint.transform.forward * forwordInput * speed);
        poweupIndicator.transform.position = transform.position;
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        isOnTouch = false;
        poweupIndicator.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            isOnTouch = true;
            Destroy (other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        poweupIndicator.SetActive(true);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& isOnTouch) {


    Rigidbody playeRb =(collision.gameObject.GetComponent<Rigidbody>());
            Vector3 enemyRig = collision.gameObject.transform.position - transform.position;
            playeRb.AddForce(enemyRig* powerUpStre , ForceMode.Impulse);

            
        }
    }
}
