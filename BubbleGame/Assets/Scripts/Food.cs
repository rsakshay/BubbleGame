using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public GameObject bubble;

	// Use this for initialization
	void Start () {
        bubble = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        GameManager.Instance.foodObjectsOnScreen--;
    }

}
