using UnityEngine;

public class KunaiHandle : MonoBehaviour
{
    public Collider playerCollider;
    public Kunai kunai;

    void OnTriggerEnter(Collider other){
        if(playerCollider == other){
            kunai.PickUp();
        }
    }
}
