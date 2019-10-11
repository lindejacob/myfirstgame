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
    public GameObject UI;
    public float waitTime = 2.0f;
    public float acceleration = 1.0f;

    public float waiting = 0;
    private Vector3 startPos;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private int lane = 0;
    private float lastshoot = 0.0f;
    public int Lane { set { lane = Mathf.Clamp(value, 0, 2); } get { return lane; } }
    public float Speed { get { return speed * (Mathf.Clamp( acceleration/20, 1, 9999)); } }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lastshoot += Time.deltaTime;
        waiting += Time.deltaTime;

        if (waiting < waitTime)
            return;

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
            newBullet.GetComponent<Bullet>().speed = Speed * 2;
            lastshoot = 0;
            newBullet.transform.position = transform.position + (Vector3.up * 2);

        }
        targetPosition = new Vector3(startPos.x+(lane*Lanesize), transform.position.y, transform.position.z);
       transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

        acceleration += Time.deltaTime;

        velocity = new Vector3(0, 0, (Speed * Time.deltaTime));
        transform.position += velocity;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            UI.SetActive(true);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Coin"){
            Destroy(collision.gameObject);
           UI_Control.singleTone.Score += 1;
       

        }
    }
}
