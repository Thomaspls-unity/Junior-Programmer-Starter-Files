using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IGrabbable
{
    private MeshRenderer m_Renderer;

    private Color defaultColor;

    public string itemName;

    public abstract void ShowItem();
    public void OnDrop()
    {
        transform.SetParent(null);
        Debug.Log($"{itemName} has been dropped");
    }

    public void OnGrab(Transform grabPoint)
    {
        transform.SetParent(grabPoint);
        Debug.Log($"{itemName} has been grabbed");
    }

    public void OnHoverEnter()
    {
        m_Renderer.material.color = Color.yellow;
        ShowItem();
        Debug.Log($"{itemName} has been found");
    }

    public void OnHoverExit()
    {
        m_Renderer.material.color = defaultColor;
        Debug.Log($"{itemName} has been lost");
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        defaultColor = m_Renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
