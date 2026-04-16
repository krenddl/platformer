using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class TimedPlatform : MonoBehaviour
{
    public float visibleTime = 2f;
    public float hiddenTime = 2f;

    private TilemapRenderer tilemapRenderer;
    private Collider2D col;

    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        col = GetComponent<Collider2D>();

        StartCoroutine(TogglePlatform());
    }

    IEnumerator TogglePlatform()
    {
        while (true)
        {
            if (tilemapRenderer != null)
                tilemapRenderer.enabled = true;

            if (col != null)
                col.enabled = true;

            yield return new WaitForSeconds(visibleTime);

            if (tilemapRenderer != null)
                tilemapRenderer.enabled = false;

            if (col != null)
                col.enabled = false;

            yield return new WaitForSeconds(hiddenTime);
        }
    }
}