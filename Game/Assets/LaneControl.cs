using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneControl : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bullet;
    public float firerate = 2.0f;
    public float Lanesize = 6.0f;
    public Vector3 targetPosition;

    private Vector3 startPos;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private int lane = 0;
    private float lastshoot = 0.0f;
    public int Lane { set { lane = Mathf.Clamp(value, 0, 2); } get { return lane; } }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lastshoot += Time.deltaTime;

        float right = 0.0f;
        if (Input.GetButtonDown("Right"))
        {
            Lane++;
        }
        else if (Input.GetButtonDown("Left"))
        {
            Lane--;
        }

        if (Input.GetButton("Space") && lastshoot > firerate)
        {
            GameObject newBullet = Instantiate(bullet);
            lastshoot -= firerate;
            newBullet.transform.position = transform.position + (Vector3.up * 2);

        }
        targetPosition = new Vector3(startPos.x+(lane*Lanesize), transform.position.y, transform.position.z);
       transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        velocity = new Vector3(0, 0, (speed * Time.deltaTime));
        transform.position += velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
