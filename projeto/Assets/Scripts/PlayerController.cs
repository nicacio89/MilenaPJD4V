using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _controls;
    private Vector2 _moveInput;
    private bool _isShooting;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }
    

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        _controls = new GameControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnAction(InputAction.CallbackContext playerAct)
    {
        if (playerAct.action.name == _controls.Gameplay.Shoot.name)
        {
            // Fazer o jogador atirar
            // Input antigo
            // KeyDown (no momento que o jogador aperta)
            // Key (enquanto o jogador esta apertando)
            // KeyUp (no momento em que o jogador solta)
            // Input System
            // playerAct.started (quando o jogadr aperta)
            // playerAct.performed (parece mais o start, não muito usado em gameplay)
            // playerAct.canceled ( no momento em que o jogador solta)
            
            //pra atirar:
            // Esquema 1: Atira uma vez a cada apertada de botão
            //Esquema 2: Atira enquanto o botão estiver pressionado
            
            //Implementando esquema 2:
            if (playerAct.started)
                _isShooting = true;
            else if (playerAct.canceled)
                _isShooting = false;
        }

        if (playerAct.action.name == _controls.Gameplay.Movement.name)
        {
            _moveInput = playerAct.ReadValue<Vector2>();
        }
    }
}
