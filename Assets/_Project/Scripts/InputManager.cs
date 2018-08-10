using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Movement Buttons")]
    public ButtonBehaviour movementButtonUp;
    public ButtonBehaviour movementButtonDown;
    public ButtonBehaviour movementButtonRight;
    public ButtonBehaviour movementButtonLeft;

    [Header("Attack Direction Buttons")]
    public ButtonBehaviour attackDirectionButtonUp;
    public ButtonBehaviour attackDirectionButtonDown;
    public ButtonBehaviour attackDirectionButtonRight;
    public ButtonBehaviour attackDirectionButtonLeft;

    [Header("Attack Pattern Display")]
    public ButtonBehaviour confirmAttackButton;
    public ButtonBehaviour cancelAttackButton;
    
    [HideInInspector] public UnityEventVector2Int OnPlayerMovePressed;
    [HideInInspector] public UnityEventVector2Int OnAttackDirectionPressed;
    [HideInInspector] public UnityEvent OnAttackConfirmPressed;
    [HideInInspector] public UnityEvent OnAttackCancelPressed;

    private void Start()
    {
        movementButtonUp.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.up);
        });
        movementButtonDown.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.down);
        });
        movementButtonRight.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.right);
        });
        movementButtonLeft.OnClick.AddListener(delegate
        {
            OnPlayerMovePressed.Invoke(Vector2Int.left);
        });

        attackDirectionButtonUp.OnClick.AddListener(delegate
        {
            OnAttackDirectionPressed.Invoke(Vector2Int.up);
        });
        attackDirectionButtonDown.OnClick.AddListener(delegate
        {
            OnAttackDirectionPressed.Invoke(Vector2Int.down);
        });
        attackDirectionButtonRight.OnClick.AddListener(delegate
        {
            OnAttackDirectionPressed.Invoke(Vector2Int.right);
        });
        attackDirectionButtonLeft.OnClick.AddListener(delegate
        {
            OnAttackDirectionPressed.Invoke(Vector2Int.left);
        });

        confirmAttackButton.OnClick.AddListener(delegate
        {
            OnAttackConfirmPressed.Invoke();
        });
        cancelAttackButton.OnClick.AddListener(delegate
        {
            OnAttackCancelPressed.Invoke();
        });

        SetAttackCancelButton(false);
        SetAttackConfirmButton(false);
        SetAttackDirectionButtons(false);
    }

    public void SetMovementButtons(bool value)
    {
        movementButtonUp.gameObject.SetActive(value);
        movementButtonDown.gameObject.SetActive(value);
        movementButtonRight.gameObject.SetActive(value);
        movementButtonLeft.gameObject.SetActive(value);
    }
    public void SetAttackDirectionButtons(bool value)
    {
        attackDirectionButtonUp.gameObject.SetActive(value);
        attackDirectionButtonDown.gameObject.SetActive(value);
        attackDirectionButtonRight.gameObject.SetActive(value);
        attackDirectionButtonLeft.gameObject.SetActive(value);
    }
    public void SetAttackCancelButton(bool value)
    {
        cancelAttackButton.gameObject.SetActive(value);
    }
    public void SetAttackConfirmButton(bool value)
    {
        confirmAttackButton.gameObject.SetActive(value);
    }
}
