using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton_Agregar : MonoBehaviour
{
    public Button yourButton; // Referencia al botón
    public Animator[] animatorsToActivate; // Animadores que deseas activar
    public GameObject[] modelsToActivate; // Modelos que deseas activar
    public GameObject[] modelsToDeactivate; // Modelos que deseas desactivar
    public GameObject[] modelsToActivateWithDelay; // Modelos que deseas activar con retraso
    public GameObject[] modelsToDeactivateWithDelay; // Modelos que deseas desactivar con retraso
    public float activationDelay = 1.0f; // Tiempo de retraso en segundos para activar modelos
    public float deactivationDelay = 1.0f; // Tiempo de retraso en segundos para desactivar modelos


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

        // Desactivar modelos
        foreach (GameObject model in modelsToDeactivate)
        {
            if (model != null)
            {
                model.SetActive(false);
            }
        }

        // Activar modelos con retraso
        foreach (GameObject model in modelsToActivateWithDelay)
        {
            if (model != null)
            {
                StartCoroutine(ActivateWithDelay(model, activationDelay));
            }
        }

        // Desactivar modelos con retraso
        foreach (GameObject model in modelsToDeactivateWithDelay)
        {
            if (model != null)
            {
                StartCoroutine(DeactivateWithDelay(model, deactivationDelay));
            }
        }
    }

    IEnumerator ActivateWithDelay(GameObject model, float delay)
    {
        yield return new WaitForSeconds(delay);
        model.SetActive(true);
    }

    IEnumerator DeactivateWithDelay(GameObject model, float delay)
    {
        yield return new WaitForSeconds(delay);
        model.SetActive(false);
    }

}

