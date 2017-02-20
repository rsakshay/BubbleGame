using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

    bool hasFood;
    public GameObject SplashPrefab;

	// Use this for initialization
	void Start () {
        hasFood = false;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food" && hasFood == false && other.GetComponent<Food>().bubble == null)
        {
            other.GetComponent<Food>().bubble = gameObject;
            other.transform.position = transform.position;
            other.GetComponent<Rigidbody2D>().gravityScale = -0.39f;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * -1.0f + other.GetComponent<Rigidbody2D>().velocity.normalized * 2.0f;
            other.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;

            hasFood = true;
        }

        //if (other.tag == "Goal" && hasFood == true)
        //{
        //    Destroy(gameObject);
        //    Destroy((GameObject)Instantiate(SplashPrefab, transform.position, Quaternion.identity), 1.0f);
        //}
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
