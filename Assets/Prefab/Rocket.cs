using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 4, Camera.main.transform.position.z);

        float spacebar = Input.GetAxis("Jump");
        Vector3 force = new Vector3(0, spacebar, 0) * 1000 * Time.deltaTime;
        _rigidbody.AddRelativeForce(force, ForceMode.Impulse);
    }
}
