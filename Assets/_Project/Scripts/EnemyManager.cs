using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour, IMapElement, ICharacter
{
    private Vector2Int staticPosition;

    #region ICharacter
    public void SetOnDeathCallback(Action callback)
    {
        throw new NotImplementedException();
    }
    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region IMapElement
    public Vector2Int GetPosition()
    {
        return staticPosition;
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }
    public void SetPosition(Vector2Int position)
    {
        transform.position = (Vector2)position;
        staticPosition = position;
    }
    public void Move(Vector2Int position)
    {
        Tweener positionTweener = transform.DOMove((Vector2)position, 0.5f);
        positionTweener.SetEase(Ease.InBounce);
        staticPosition = position;
    }
    #endregion
}
