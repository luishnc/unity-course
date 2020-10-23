using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;

    //Player's fireRate 0.25f
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;


    void Start()
    {
        Debug.Log("Start is called");
        //Initial position
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {


        Shoot();
        Movement();
    }

    private void Shoot()
    {
        //spawn laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > _canFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                _canFire = Time.time + _fireRate;
            }
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //let player move up/down or left/right
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        //adding control to not cross over the map limit
        if (transform.position.x > 8.0f)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x < -8.0f)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
        else if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
    }


}