using UnityEngine;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpSpeed = 10f;
    CharacterController characterController;
    public Transform groundCheckTransform;
    public LayerMask jumpLayers;
    public int maxJumps = 2;
    public int jumpsLeft = 2;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip pickupSound;
    //public AudioClip jumpSound;

    [Header("Smoke Bombs")]

    public GameObject smokeBombPrefab;



    [Header("Throwing Stars")]
    public GameObject throwingStarPrefab;
    public float throwingStarSpeed = 10f;
    public int maxThrowingStars = 10;
    public int throwingStarsLeft = 10;

    void Awake(){
        characterController = GetComponent<CharacterController>();
        jumpsLeft = maxJumps;
    }

    void Start(){
        throwingStarsLeft = maxThrowingStars;

    }

    void Update(){
        ApplyGravityToCC();
    }



    public void PoofSmokeBomb(){
        Instantiate(smokeBombPrefab, transform.position, Quaternion.identity);
    }

    public void ThrowStar(){
        if(throwingStarsLeft < 1){
            return;
        }

        throwingStarsLeft--;


        GameObject newStar = Instantiate(throwingStarPrefab, transform.position, Quaternion.identity);
        newStar.GetComponent<Rigidbody>().linearVelocity = transform.forward * throwingStarSpeed;
        Destroy(newStar,30f);
    }

    void RefillStars(GameObject refillBox){
        throwingStarsLeft = maxThrowingStars;
        audioSource.resource = pickupSound;
        audioSource.Play();
        //audioSource.PlayOneShot(pickupSound);
        Destroy(refillBox);
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("ThrowingStarRefill")){
            Debug.Log("Refill stars");
            RefillStars(other.gameObject);
        }
        if(other.CompareTag("Obstacle")){
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void Move(Vector3 direction){
        transform.position += direction * speed * Time.deltaTime;
        if(direction == Vector3.zero){
            return;
        }
        transform.LookAt(transform.position + direction);
    }

    public void MoveWithRB(Vector3 direction){
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        transform.LookAt(transform.position + direction);
    }

    public void MoveWithCC(Vector3 direction){
        characterController.Move(direction * speed * Time.deltaTime);
        transform.LookAt(transform.position + direction);
    }

    Vector3 gravityVelocity = Vector3.zero;
    void ApplyGravityToCC(){
        if(characterController.isGrounded && gravityVelocity.y < 0){ //TODO use a spherecast instead!
            gravityVelocity = Vector3.zero;
            return;
        }
        gravityVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravityVelocity * Time.deltaTime);
    }

    public void Jump(){
        if(CreatureOnGround())
        {
            jumpsLeft = maxJumps;
        }else if(jumpsLeft < 1){
            return;
        }
        jumpsLeft--;
        if(gravityVelocity.y < 0){
            gravityVelocity.y = 0;
        }
        gravityVelocity.y += jumpSpeed;
    }

    public bool CreatureOnGround(){
        return Physics.OverlapSphere(groundCheckTransform.position,0.5f,jumpLayers).Length > 0;
    }

    public void TeleportRandomly(){
        Debug.Log("Teleporting");
        Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        characterController.enabled = false;
        transform.position = randomPosition;
        characterController.enabled = true;
    }




}
