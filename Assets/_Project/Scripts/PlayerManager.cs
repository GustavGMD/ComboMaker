using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour, IMapElement, ICharacter
{
    [SerializeField] private AttackPattern currentWeapon;

    private Vector2Int staticPosition;

	#region ICharacter
	public void SetOnDeathCallback(Action callback)
    {
        throw new NotImplementedException();
    }

    public Vector2Int[] GetAttackPattern()
    {
        return currentWeapon.hitPositions;
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
        //Tweener scaleTweener = transform.DOPunchScale(Vector3.one * 0.7f, 0.5f);
        positionTweener.SetEase(Ease.OutBounce);
        staticPosition = position;
    }
    #endregion
}
