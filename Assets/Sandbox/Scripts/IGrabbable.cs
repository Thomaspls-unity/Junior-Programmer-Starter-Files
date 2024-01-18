using UnityEngine;

public interface IGrabbable
{
    public void OnGrab(Transform grabPoint);
    public void OnDrop();
    public void OnHoverEnter();
    public void OnHoverExit();
}