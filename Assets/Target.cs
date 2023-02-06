using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 4;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public int pointValue;

    public ParticleSystem explosionParticle;

    private GameManager gameM;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddForce(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomSpawnPos();

        gameM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 randomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float randomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown() {
        if (gameM.gameActive) {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameM.addScore(pointValue);
            if (gameObject.tag == "Bad") {
                gameM.gameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
