using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursores")]
    public Texture2D cursorNormal;
    public Texture2D cursorClick;

    [Header("Configuração")]
    public CursorMode cursorMode = CursorMode.ForceSoftware; // força tamanho real
    private Vector2 hotspotNormal;
    private Vector2 hotspotClick;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        // Define o hotspot no centro das texturas
        if (cursorNormal != null)
            hotspotNormal = new Vector2(cursorNormal.width / 2, cursorNormal.height / 2);

        if (cursorClick != null)
            hotspotClick = new Vector2(cursorClick.width / 2, cursorClick.height / 2);

        SetCursorNormal();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetCursorClick();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetCursorNormal();
        }
    }

    public void SetCursorNormal()
    {
        if (cursorNormal != null)
            Cursor.SetCursor(cursorNormal, hotspotNormal, cursorMode);
    }

    public void SetCursorClick()
    {
        if (cursorClick != null)
            Cursor.SetCursor(cursorClick, hotspotClick, cursorMode);
    }
}