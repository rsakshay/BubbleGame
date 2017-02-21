using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    Rigidbody2D rgb2d;

	// Use this for initialization
	void Start () {

        rgb2d = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        rgb2d.velocity = new Vector2(1.8f * Mathf.Cos(Time.time/3), 0.0f);
        rgb2d.velocity.Normalize();
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            GameManager.Instance.score++;
            Destroy(other.gameObject);

            Destroy(other.GetComponent<Food>().bubble);
            Destroy((GameObject)Instantiate(other.GetComponent<Food>().bubble.GetComponent<Bubble>().SplashPrefab, transform.position, Quaternion.identity), 1.0f);
        }
    }
}
