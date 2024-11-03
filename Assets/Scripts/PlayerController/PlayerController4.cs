using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController4 : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;

    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip startClip;
    [SerializeField] private AudioClip winClip;

    public float speed = 10.0f;

    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;

    private bool jump;
    private bool isGrounded;
    public float jumpPower = 0.3f;

    private void Start()
    {
        AudioManager.instance.PlaySoundFXClip(startClip, transform, 1f);
        winText.gameObject.SetActive(false);
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            AudioManager.instance.PlaySoundFXClip(coinClip, transform, 1f);
        }
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if (count >= 8)
        {
            AudioManager.instance.PlaySoundFXClip(winClip, transform, 1f);
            winText.gameObject.SetActive(true);
            Invoke("NextLevel", 3);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
