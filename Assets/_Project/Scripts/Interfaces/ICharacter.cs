using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
 {
	//setters
	void SetOnDeathCallback(System.Action callback);

    Vector2Int[] GetAttackPattern();
	void TakeDamage(int damage);
}
