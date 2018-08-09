using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapElement
{
    //Getters
    Vector2Int GetPosition();
    GameObject GetGameObject();

    //Setters
    void SetPosition(Vector2Int position);

    //Actions
    void Move(Vector2Int position);
}
