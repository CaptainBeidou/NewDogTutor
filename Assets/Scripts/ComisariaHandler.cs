using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ComisariaHandler : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector house;
    [SerializeField]
    private StoryCinematicDirector director;
    public GameObject bubbleUi;
    private GameObject bubbleUse;
    private Vector3 localPosition = new Vector3 (-0.7f,1.6f);
    [SerializeField] private Transform lidiaTransform;
    [SerializeField] private Transform inspectorTransform;
    [SerializeField] private Transform felixTransform;
    [SerializeField] private GameObject tutorial;

    private float key = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        bubble(lidiaTransform, "Inspector, ¡ayuda!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && key == 0)
        {
            Destroy(bubbleUse);
            Destroy(tutorial);
            bubble(inspectorTransform, "Es Lidia Acosta, ¿Qué ocurrió?");
            key++;
        } else if (Input.GetKeyDown(KeyCode.Space) && key == 1)
        {
            Destroy(bubbleUse);
            bubble(lidiaTransform, "Han entrado a mi casa y me han robado mis joyas");
            key++;
        } else if (Input.GetKeyDown(KeyCode.Space) && key == 2)
        {
            Destroy(bubbleUse);
            bubble(felixTransform, "No se preocupe, ¡nosotros nos encargaremos!");
            key++;
        } else if (Input.GetKeyDown(KeyCode.Space) && key == 3)
        {
            Destroy(bubbleUse);
            director.PlayCinematic(house);
        }
    }

    private void bubble(Transform charTransform, string text)
    {
        bubbleUse = Instantiate(bubbleUi, FindObjectOfType<Canvas>().transform);
        bubbleUse.transform.position = Camera.main.WorldToScreenPoint(charTransform.position+localPosition);
        bubbleUse.GetComponent<ChatBubble>().Setup(text);
    }
}
