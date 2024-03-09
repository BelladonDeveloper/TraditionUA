using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
public class ConeFall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shadowSpriteRenderer;
    [SerializeField] private SpriteRenderer coneSpriteRenderer;
    [SerializeField] private Transform ConeTF;
    [SerializeField] private Rigidbody ConeRB;
    [SerializeField] private Transform ShadowTF;
    [SerializeField] private Transform ShadowTF_Y_Prefab;
    [SerializeField] private KrampusMinigame krampusMinigame;
    private bool CanLose = true;
    private float TorquePower;

    private void Start() 
    {
        Vector3 XRandomizer = new Vector3(Random.Range(-5,5),0,0);
        ConeTF.position += XRandomizer;
        TorquePower = Random.Range(-1.5f,1.5f);
        ConeRB.velocity = new Vector3(TorquePower, 0, 0);
        ConeRB.angularVelocity = new Vector3(0, 0, TorquePower*3);
        Sequence ShowShadow = DOTween.Sequence();
        ShowShadow.Append(shadowSpriteRenderer.DOColor(new Color(1, 1, 1, 150f/255f), 0.5f));
        ShowShadow.Play();
    }
    private void Update() 
    {
        SetShadowTransform();
    }
    private void SetShadowTransform()
    {
        Vector3 FixTF = new Vector3(ConeTF.position.x, ShadowTF_Y_Prefab.position.y,ConeTF.position.z);
        ShadowTF.position = FixTF;
        ShadowTF.rotation = ShadowTF_Y_Prefab.rotation;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player") && CanLose)
        {
            krampusMinigame.Lose();
        }
        if(collision.gameObject.CompareTag("Terrain"))
        {
            CanLose = false;

            Sequence Disappear = DOTween.Sequence();
            Disappear.Append(shadowSpriteRenderer.DOColor(new Color(1, 1, 1, 0), 0.5f));
            Disappear.Join(coneSpriteRenderer.DOColor(new Color(1, 1, 1, 0), 0.5f));
            Disappear.OnComplete(OnDisappearComplete);
            Disappear.Play();
        }
    }

    private void OnDisappearComplete()
    {
        Destroy(gameObject);
    }

}
