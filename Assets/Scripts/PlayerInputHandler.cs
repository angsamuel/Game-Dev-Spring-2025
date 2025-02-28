using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInputHandler : MonoBehaviour
{


    public Creature playerCreature;
    public Creature dogCreature;
    public Kunai kunai;
    public Transform cameraTransform;
    public Transform cameraPivotTransform; //rotate to look
    public float cameraPivotSpeed = 100f;
    TimeManager timeManager;


    //Creature creature;
    void Awake(){
        timeManager = GetComponent<TimeManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //creature = creatureObject.GetComponent<Creature>();
        Debug.Log(cameraTransform.forward);
        Cursor.visible = false;
        // Cursor.visible = true;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;

    }

    void FixedUpdate()
    {

        // Vector3 cameraForward = cameraTransform.forward;
        // cameraForward.y = 0;

        // Vector3 cameraRight = cameraTransform.right;
        // cameraRight.y = 0;

        // Vector3 finalMovement = Vector3.zero;

        // if (Input.GetKey(KeyCode.W))
        // {
        //     finalMovement += cameraForward;
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     finalMovement -= cameraForward;
        // }

        // if (Input.GetKey(KeyCode.A))
        // {
        //     finalMovement -= cameraRight;
        // }

        // if (Input.GetKey(KeyCode.D))
        // {
        //     finalMovement += cameraRight;
        // }

        // finalMovement.Normalize();


        // creature.MoveWithRB(finalMovement);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;

        Vector3 finalMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            finalMovement += cameraForward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            finalMovement -= cameraForward;
        }

        if (Input.GetKey(KeyCode.A)){
            finalMovement -= cameraRight;
        }

        if(Input.GetKey(KeyCode.D)){
            finalMovement += cameraRight;
        }

        finalMovement.Normalize();

        //creature.Move(finalMovement);
        playerCreature.MoveWithCC(finalMovement);

        if (Input.GetKeyDown(KeyCode.E))
        {
           playerCreature.PoofSmokeBomb();
        }

        if(Input.GetKeyDown(KeyCode.T)){
            playerCreature.TeleportRandomly();
        }


        if(Input.GetKeyDown(KeyCode.F)){
            playerCreature.ThrowStar();
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            playerCreature.Jump();
        }



        if(Input.GetKey(KeyCode.O)){
            cameraPivotTransform.Rotate(new Vector3(0,1,0), -cameraPivotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.P))
        {
            cameraPivotTransform.Rotate(Vector3.up, cameraPivotSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.R)){
            timeManager.ToggleSlowTime();
        }


        if(Input.GetKeyDown(KeyCode.Mouse1)){
            dogCreature.Jump();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            kunai.Shoot();
        }

    }
}
