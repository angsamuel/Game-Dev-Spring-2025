using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    public GameObject player;
    public Color canHitColor;
    public Color noHitColor;
    public Renderer myRenderer;
    public Transform kunai;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        kunai.transform.LookAt(transform.position);
        if (!Physics.Linecast(player.transform.position, transform.position, out hit, LayerMask.GetMask("Terrain"))){
            myRenderer.material.color = canHitColor;
            kunai.localScale = Vector3.one;

        }
        else{
            myRenderer.material.color = noHitColor;
            kunai.localScale = Vector3.zero;
        }
    }
}
