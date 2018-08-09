using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
 {
	 //setters
	 void SetOnDeathCallback(System.Action callback);
	 
	void TakeDamage(int damage);
}
