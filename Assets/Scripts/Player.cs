
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private GameObject _explosionPrefab;

    //Player's fireRate 0.25f
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private int lives = 3;

    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;

    //variable used for triple shoot
    [SerializeField]
    public bool canTripleShot = false;

    //Variable used for speed boost
    public bool isSpeedBoostActive = false;



    void Start()
    {
        Debug.Log("Start is called");
        //Initial position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        Movement();
    }





    private void Shoot()
    {
        //spawn laser


        if (Time.time > _canFire)
        {
            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                
            }

            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
             
            }

            _canFire = Time.time + _fireRate;
        }
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        //let player move up/down or left/right


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

        //implementing speed boost
        if (isSpeedBoostActive)
        {
            transform.Translate(Vector3.right * speed * 1.5f *  horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * 1.5f * verticalInput * Time.deltaTime);

        } else

        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }
    }

    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }


    //method for speed boost enable/disable
    public void SpeedBoostPowerupOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostDownRoutine());

    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    public void Damage()
    {
        //subtract 1 life from the player
        //if lives < 1 destroy the player
        lives--;

        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }










}