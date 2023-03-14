using UnityEngine;

public class GhoulScript : MonoBehaviour
{
    private Animation animations;

    //static int nbMaxGhouls = 2;
    //static int nbrGhoul = 0;

    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        //Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity); // Cr�ation d'un objet � la position 0,0,0
        //verifier que y a pas plus de nbMaxGhouls a l'instancier
        //if (nbrGhoul < nbMaxGhouls)
        //{
        //    Instantiate(gameObject, new Vector3(1, 1, 0), Quaternion.identity); // Cr�ation d'un objet � la position 0,0,0
        //    nbrGhoul++;
        //}
    }

    void Update()
    {
        // V�rification si l'utilisateur touche l'�cran
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la cam�ra vers le point de touch�
            RaycastHit hit; // Informations sur l'objet touch�

            // D�tection de l'objet touch�
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
//        // V�rification si l'utilisateur touche l'�cran
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Rayon depuis la cam�ra vers le point de touch�
//            RaycastHit hit; // Informations sur l'objet touch�

//            // D�tection de l'objet touch�
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