using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        // Vérification si l'utilisateur touche l'écran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la caméra vers le point de touché
            RaycastHit hit; // Informations sur l'objet touché

            // Détection de l'objet touché
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    animations.Play("Death");
                }
            }
        }

        if (animations.isPlaying && animations["Death"].time >= animations["Death"].length)
        {
            animations.Stop();
            animations.Play("Run");
        }
    }
}