using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class ChangeAlpha : MonoBehaviour
{
    private const string INTERACTABLE_OBJECT = "Interactable";

    private List<GameObject> interactableObjects = new List<GameObject>();
    private Sequence alphaSequence;
    private Sequence metallicSequence;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(INTERACTABLE_OBJECT))
        {
            GameObject obj = other.gameObject;
            interactableObjects.Add(obj);
            ChangeMaterialProperties(obj, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(INTERACTABLE_OBJECT))
        {
            GameObject obj = other.gameObject;
            interactableObjects.Remove(obj);
            ChangeMaterialProperties(obj, 1f);
        }
    }

    private void ChangeMaterialProperties(GameObject obj, float targetAlpha)
    {
        Renderer renderer = obj.GetComponentInChildren<Renderer>();

        if (renderer != null)
        {
            if (alphaSequence != null)
            {
                alphaSequence.Kill();
            }

            if (metallicSequence != null)
            {
                metallicSequence.Kill();
            }

            alphaSequence = DOTween.Sequence();
            metallicSequence = DOTween.Sequence();

            Material material = renderer.material;

            alphaSequence.Join(material.DOFade(targetAlpha, 0.5f));
            metallicSequence.Join(material.DOFloat(targetAlpha, "_Metallic", 0.5f));
        }
    }
}