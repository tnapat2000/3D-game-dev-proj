using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    public float dashSpeedMult = 1.5f;
    public int maxHealth = 100;
    public static int currentHealth;
    Vector3 velocity;
    public Transform groudCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    private float nextTimeToFire = 0f;
    public float cooldown = 5f;
    public bool canDash = true;
    public Vector3 deadKick;
    public bool isAlive;
    public HealthBar healthBar;

    // public static int currentHealth = 100;
    // public Slider healthBarSli;
    // public static bool gameOver;
    public float reloadDelay = 5;

    // Start is called before the first frame update
    void Start()
    {   
        isAlive = true;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHP(maxHealth);
        // gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive){return;}
        if (currentHealth <= 0 && isAlive) {
            transform.localEulerAngles += deadKick;
            isAlive = false;
            Die();
            return;
        }
        // Debug.Log(currentHealth);
        Walk();
        if ( Time.time > nextTimeToFire){
            canDash = true;
            // Debug.Log("can dash");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            nextTimeToFire += cooldown;         
            canDash = false;
            Dash();
        }
        //update the slider value
        healthBar.SetHealth(currentHealth);
        //game over
       
    }

    public void Walk(){
        if (!isAlive){return;}
        isGrounded = Physics.CheckSphere(groudCheck.position, groundDistance, groundMask);        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(int amount){
        Debug.Log(amount);
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        // Debug.Log("currentHP: " + currentHealth);
    }

    public void Dash(){      
        if (!isAlive){return;}  
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0 && x != 0 ){
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * dashSpeedMult * speed  * Time.deltaTime);
        }else{
            // Vector3 move = transform.right * x + transform.forward * 10;
            controller.Move(transform.forward * dashSpeedMult * speed  * Time.deltaTime);
        }
    }

    void Die(){
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel(){
        yield return new WaitForSecondsRealtime(reloadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other){
        // Debug.Log(other.gameObject.name);
        if(other.tag == "Door"){
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex +1;
            if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
