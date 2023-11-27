using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Speed
    private Vector3 moveDirection = Vector3.right;

    public AudioClip popSound; 
    private AudioSource audioSource; 
    public TextMeshProUGUI scoreText; 

    private static int numPopped = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = popSound;

        Invoke("PopBalloon", 10.0f);

        InvokeRepeating("GrowBalloon", 1.0f, Time.deltaTime);
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        CheckScreenEdges();
    }

    void CheckScreenEdges()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x <= 0 || screenPos.x >= Screen.width)
        {
            moveDirection = -moveDirection;
        }
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Pin"))
    {
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);

        float scaleThreshold = 0.16f; 
        if (transform.localScale.x > scaleThreshold)
        {
            numPopped += 3;
        }
        else
        {
            numPopped++;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}


    void PopBalloon()
    {
        numPopped--;

        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);

        Destroy(gameObject);
    }

    void GrowBalloon()
    {
        transform.localScale += new Vector3(0.0006f, 0.0006f, 0.0006f);
    }
    
    public static void ResetNumPopped()
    {
        numPopped = 0;
    }

    public int GetNumPopped()
    {
        return numPopped;
    }
}

