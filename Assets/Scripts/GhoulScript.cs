using System.Collections;
using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;

    //static int nbMaxGhouls = 2;
    //static int nbrGhoul = 0;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        //Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity); // Création d'un objet à la position 0,0,0
        //verifier que y a pas plus de nbMaxGhouls a l'instancier
        //if (nbrGhoul < nbMaxGhouls)
        //{
        //    Instantiate(gameObject, new Vector3(1, 1, 0), Quaternion.identity); // Création d'un objet à la position 0,0,0
        //    nbrGhoul++;
        //}
    }

    void Update()
    {
        killObject(gameObject);
    }
    void killObject(GameObject gameObject)
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

        shutDownAnnimation();
    }

    void shutDownAnnimation()
    {
        if (animations.isPlaying && animations["Death"].time >= animations["Death"].length)
        {
            animations.Stop();

            // Génération d'une position aléatoire pour le nouveau Ghoul
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);
            float randomZ = UnityEngine.Random.Range(-1f, 1f);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
            
            Instantiate(gameObject, randomPosition, Quaternion.identity);
            Destroy(gameObject);

        }
    }

private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            animations.Play("Death");
            Destroy(other.gameObject);
        }
    }
}


//using UnityEngine;

//public class GhoulScript : MonoBehaviour
//{
//    private Animation animations;

//    void Start()
//    {
//        animations = gameObject.GetComponent<Animation>();
//    }

//    void Update()
//    {
//        // Vérification si l'utilisateur touche l'écran
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la caméra vers le point de touché
//            RaycastHit hit; // Informations sur l'objet touché

//            // Détection de l'objet touché
//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.transform.gameObject == gameObject)
//                {
//                    animations.Play("Death");
//                }
//            }
//        }

//        if (animations.isPlaying && animations["Death"].time >= animations["Death"].length)
//        {
//            animations.Stop();
//        }
//    }
//}