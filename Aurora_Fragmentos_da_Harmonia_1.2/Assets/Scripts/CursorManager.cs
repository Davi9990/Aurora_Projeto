using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursores")]
    public Texture2D cursorNormal;
    public Texture2D cursorClick;

    [Header("Configuração")]
    public Vector2 hotspot = Vector2.zero; // Define o ponto "ativo" do cursor
    public CursorMode cursorMode = CursorMode.Auto;

    private void Start()
    {
        // Faz o objeto não ser destruído ao trocar de cena
        DontDestroyOnLoad(gameObject);

        // Começa com o cursor normal
        SetCursorNormal();
    }

    private void Update()
    {
        // Troca pro cursor de clique quando o botão esquerdo for pressionado
        if (Input.GetMouseButtonDown(0))
        {
            SetCursorClick();
        }

        // Volta pro cursor normal quando soltar o botão
        if (Input.GetMouseButtonUp(0))
        {
            SetCursorNormal();
        }
    }

    public void SetCursorNormal()
    {
        if (cursorNormal != null)
        {
            Cursor.SetCursor(cursorNormal, hotspot, cursorMode);
            //Debug.Log("Cursor Normal ativado");
        }
    }

    public void SetCursorClick()
    {
        if (cursorClick != null)
        {
            Cursor.SetCursor(cursorClick, hotspot, cursorMode);
            //Debug.Log("Cursor Click ativado");
        }
    }
}
