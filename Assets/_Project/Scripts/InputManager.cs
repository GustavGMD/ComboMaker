using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public UnityEventVector2Int OnPlayerMovePressed;

    public ButtonBehaviour buttonUp;
    public ButtonBehaviour buttonDown;
    public ButtonBehaviour buttonRight;
    public ButtonBehaviour buttonLeft;
    
    private void Start()
    {
        buttonUp.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.up);
        });
        buttonDown.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.down);
        });
        buttonRight.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.right);
        });
        buttonLeft.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.left);
        });
    }
}
