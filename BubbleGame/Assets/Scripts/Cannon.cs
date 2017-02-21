using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject AlmondPrefab;

    float lastFoodCastTime;

	// Use this for initialization
	void Start () {
        lastFoodCastTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0.0f;

        Vector3 almondPos = new Vector3(0.0f, -3.6f, 0.0f);

        Vector3 targetDir = mousePos - transform.position;
        targetDir.Normalize();

        float angle = Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Space) && ((Time.time - lastFoodCastTime) > GameManager.Instance.foodCastDelay) && GameManager.Instance.foodObjectsOnScreen < GameManager.Instance.foodOnScreenLimit)
        {
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.z = 0.0f;

            //Vector3 almondPos = new Vector3(0.0f, -3.6f, 0.0f);

            //Vector3 targetDir = mousePos - almondPos;
            //targetDir.Normalize();

            //float angle = Mathf.Atan2(targetDir.x, targetDir.y) * Mathf.Rad2Deg;

            GameObject almond = Instantiate(AlmondPrefab, transform.position, transform.rotation) as GameObject;

            GameManager.Instance.foodObjectsOnScreen++;

            almond.GetComponent<Rigidbody2D>().velocity = almond.transform.up * 10.0f;

            lastFoodCastTime = Time.time;
        }
	}
}
