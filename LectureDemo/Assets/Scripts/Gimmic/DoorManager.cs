using System;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Door[] doors;
    event Action Opened, Closed, Toggled;

    void Start()
    {
        foreach (var door in doors = GetComponentsInChildren<Door>())
        {
            Opened += door.Open;
            Closed += door.Close;
            Toggled += door.ToggleOpen;
        }
    }

    void OnDestroy()
    {
        foreach (var door in doors)
        {
            Opened -= door.Open;
            Closed -= door.Close;
            Toggled -= door.ToggleOpen;
        }
    }

    public void OnOpen()
    {
        if(Opened != null)
        {
            Opened();
        }
    }

    public void OnClose()
    {
        if(Closed != null)
        {
            Closed();
        }
    }

    public void OnToggle()
    {
        if(Toggled != null)
        {
            Toggled();
        }
    }
}
