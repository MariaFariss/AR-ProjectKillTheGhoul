
using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;
    private BoxCollider boxCollider;
    private int distance = 5;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * distance);


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            transform.Rotate(Vector3.up * Random.Range(90, 180));
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Player");
                animations.Play("Attack1");
            }
            else
            {
                animations.Play("Run");
            }
        }
    }



}
