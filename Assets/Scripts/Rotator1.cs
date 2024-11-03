using UnityEngine.InputSystem;
using UnityEngine;

public class Rotator1 : MonoBehaviour
{

    private bool jump;

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");

        if (jump)
        {
            Debug.Log("Salta");
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
        transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
    }
}
