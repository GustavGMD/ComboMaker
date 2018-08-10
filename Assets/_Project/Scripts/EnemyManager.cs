using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour, IMapElement, ICharacter
{
    [SerializeField] private AttackPattern currentWeapon;
    private Vector2Int staticPosition;

    private Action onDeath;

    #region ICharacter
    public void SetOnDeathCallback(Action callback)
    {
        onDeath = callback;
    }

    public Vector2Int[] GetAttackPattern()
    {
        return currentWeapon.hitPositions;
    }
    public void TakeDamage(int damage)
    {
        onDeath.Invoke();
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
