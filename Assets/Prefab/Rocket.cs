using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 30);

        float spacebar = Input.GetAxis("Jump");

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.right * 100 * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.left * 100 * Time.deltaTime);


        Vector3 force = new Vector3(0, spacebar, 0) * 1000 * Time.deltaTime;
        _rigidbody.AddRelativeForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("KillBrick"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
