using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton_Añadir : MonoBehaviour
{
    public Button yourButton; // Referencia al botón
    public Animator[] animatorsToActivate; // Animadores que deseas activar
    public GameObject[] modelsToActivate; // Modelos que deseas activar
   

    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // Activar animaciones
        foreach (Animator animator in animatorsToActivate)
        {
            if (animator != null)
            {
                bool isActive = animator.GetBool("isActive");
                animator.SetBool("isActive", !isActive); // Alterna el estado de la animación
            }
        }

        // Activar modelos
        foreach (GameObject model in modelsToActivate)
        {
            if (model != null)
            {
                model.SetActive(true);
            }
        }

    }
}
