using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Trucoteca : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    private string command = "041024";
    private string currentInput = "";
    public static event Action OnFinal;

    public void OnAnyKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            string keyPressed = null;

            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                keyPressed = GetPressedKey();
            }

            if (keyPressed != null)
            {
                currentInput += keyPressed.ToUpper();

                if (currentInput.Length > command.Length)
                {
                    currentInput = currentInput.Substring(1);
                }

                if (!command.StartsWith(currentInput))
                {
                    Debug.Log("Secuencia incorrecta. Reiniciando...");
                    currentInput = "";
                }

                if (currentInput == command)
                {
                    Debug.Log("Comando completado");
                    if (targetObject != null)
                    {
                        OnFinal?.Invoke();
                        targetObject.SetActive(true);
                    }
                    currentInput = "";
                }

                Debug.Log("Entrada actual: " + currentInput);
            }
        }
    }
    private string GetPressedKey()
    {
        for (int i = 0; i < Keyboard.current.allKeys.Count; i++)
        {
            if (Keyboard.current.allKeys[i].wasPressedThisFrame)
            {
                return Keyboard.current.allKeys[i].displayName;
            }
        }
        return null;
    }
}