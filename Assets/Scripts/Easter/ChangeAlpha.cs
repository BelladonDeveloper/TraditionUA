using UnityEngine;
using DG.Tweening;

public class ChangeAlpha : MonoBehaviour
{
    private const string INTERACTABLE_OBJECT = "Interactable";

    private Sequence alphaSequence;
    private Sequence metallicSequence;
    private GameObject currentObject; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(INTERACTABLE_OBJECT))
        {
            currentObject = other.gameObject; 
            ChangeMaterialProperties(currentObject, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(INTERACTABLE_OBJECT) && other.gameObject == currentObject)
        {
            ChangeMaterialProperties(currentObject, 1f);
            currentObject = null; 
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