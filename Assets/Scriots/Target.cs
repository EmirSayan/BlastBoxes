using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTork = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem patlamaEfekti;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTork(),RandomTork(),RandomTork(),ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-xRange,xRange) , ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }
    float RandomTork()
    {
        return Random.Range(-maxTork,maxTork);
    }
    private void OnMouseDown() 
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);    
            Instantiate(patlamaEfekti, transform.position, patlamaEfekti.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);   
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
