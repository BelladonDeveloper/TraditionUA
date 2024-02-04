using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using Sequence = DG.Tweening.Sequence;

public class EasterCurrentSprite : MonoBehaviour
{
    public static EasterCurrentSprite Instance;
    public EggSprites mySpriteType;

    public const float TIME_TO_CHANGE_COLOR = 0.5f;
    public const float END_VALUE = 0f;

    private SpriteRenderer _mySpriteRenderer;
    private Color _originalColor;

    public void Start()
    {
        Instance = this;

        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = Color.white;

        ChangeType();
    }

    public void ChangeType()
    {
        string spriteName = _mySpriteRenderer.sprite.name.ToString();
        mySpriteType = (EggSprites)Enum.Parse(typeof(EggSprites), spriteName);
    }

    public void CheckSprite(SpriteRenderer spriteRenderer, EggSprites eggSprites)
    {
        Sequence colorChanging = DOTween.Sequence();
        if (spriteRenderer != null && spriteRenderer.sprite != null &&
            spriteRenderer.sprite.name.ToSafeString() == eggSprites.ToString())
        {
            _originalColor = spriteRenderer.color;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            SecondTaskManager.Singleton.EggsRemover(this.gameObject);


            colorChanging.Append(spriteRenderer.DOFade(END_VALUE, TIME_TO_CHANGE_COLOR))
                    .OnComplete(() => SetSpriteColor(spriteRenderer, Color.green));

            StartCoroutine(ChangeSpriteColorToDefault(spriteRenderer));
        }
        else
        {
            colorChanging.Append(spriteRenderer.DOFade(END_VALUE, TIME_TO_CHANGE_COLOR))
                    .OnComplete(() => SetSpriteColor(spriteRenderer, Color.red));

            StartCoroutine(ChangeSpriteColorToDefault(spriteRenderer));
        }
    }

    public void ResetSpriteColor(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.DOColor(_originalColor, TIME_TO_CHANGE_COLOR);
        }
    }

    private IEnumerator ChangeSpriteColorToDefault(SpriteRenderer spriteRenderer)
    {
        Sequence colorChanging = DOTween.Sequence();

        yield return new WaitForSeconds(1f);

        colorChanging.Append(spriteRenderer.DOFade(END_VALUE, TIME_TO_CHANGE_COLOR));

        yield return new WaitForSeconds(1f);

        ResetSpriteColor(spriteRenderer);
    }

    private void SetSpriteColor(SpriteRenderer spriteRenderer, Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.DOColor(color, TIME_TO_CHANGE_COLOR);
        }
    }
}
