using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerColor : NetworkBehaviour
{

    [SyncVar(hook = nameof(HandleDisplayColorChange))][SerializeField] private Color displayColor;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [Server]

    public void SetDisplayColor(Color newColor)
    {
        displayColor = newColor;
    }

    private void HandleDisplayColorChange(Color oldColor, Color newColor)
    {

        spriteRenderer.color = newColor;
    }
}
