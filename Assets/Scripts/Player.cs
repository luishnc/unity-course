using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5f;

    void Start()
    {
        Debug.Log("Start is called");
        //Initial position
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime );
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }


}