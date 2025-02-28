using UnityEngine;

public class Kunai : MonoBehaviour
{


    public TrainingTarget target;
    public Transform playerTransform;
    public float speed = 30f;

    bool inHand = true;

    void Update(){
        if(inHand){
            transform.position = playerTransform.position;
        }
        transform.LookAt(target.transform);


        if(CanSeeTarget()){
            
            target.CanSee();
        }else{
            target.NoCanSee();
        }   

    }

    bool CanSeeTarget(){
        RaycastHit hit;
       return !Physics.Linecast(transform.position, target.transform.position, out hit, LayerMask.GetMask("Terrain"));
    }

    void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("TrainingTarget")){
            if(GetComponent<Rigidbody>().linearVelocity == Vector3.zero){
                return;
            }
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            //other.transform.parent.GetComponent<TrainingTarget>().SetAsHit();    
            //other.GetComponent<TrainingTarget>().SetAsHit();
            target.SetAsHit();
        }
    }
    public void Shoot(){
        if(!CanSeeTarget()){
            return;
        }
        inHand = false;
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
    }

    public void PickUp(){
        
        inHand = true;
        target.Relocate();
    }
}
