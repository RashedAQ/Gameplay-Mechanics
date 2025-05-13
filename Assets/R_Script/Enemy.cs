using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EmemyRb;
    private GameObject playerGo;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        EmemyRb = GetComponent<Rigidbody>();
        playerGo = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDiraction = (playerGo.transform.position - transform.position).normalized;
        EmemyRb.AddForce(lookDiraction * speed);
        if (transform.position.y < -10)
        {

            Destroy(gameObject);
        }
    }
}