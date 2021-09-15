using UnityEngine;

public class character2d : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float JumpForce = 7;
    public bool facingRight = true;
    public Animator animator;
    public GameObject optionsMenu;
    public float groundRaycastDistance;
    public LayerMask groundLayerMask;
    private CharacterSoundController sound;
    private bool isJumping;
    private bool isOnGround;

    // RIGIDBODY 2D
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sound = GetComponent<CharacterSoundController>();
    }
    // Update is called once per frame
    private void Update()
    {
    // KODE MOVEMENT
       var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
    // KODE FLIP MOVEMENT
       if (movement < 0 && facingRight) Flip();
       if (movement > 0 && !facingRight) Flip();
    // KODE LOMPAT
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            sound = GetComponent<CharacterSoundController>();
        }

        if (isOnGround)
         {
            isJumping = true;
         }
    // ANIMATOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Run", false);
        }
    // ESCAPE

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("pause");
        } 

        
    }
    // KODE FLIP MOVEMENT
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    
    private void OnDrawGizmos()
    {
    Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), Color.white);
    }
}
