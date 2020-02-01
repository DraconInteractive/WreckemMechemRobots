using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;
public class PlayerHand : MonoBehaviour
{
    public enum Chirality
    {
        Left,
        Right
    };

    public Chirality chirality;
    public Renderer render;
    public Transform itemAnchor;
    public float interactionDist;
    InteractableItem itemInHand;
    public UnityEvent onInteract, onGrab, onRelease;
    public List<InteractableItem> interactablesInRange = new List<InteractableItem>();

    void Update()
    {
        UpdateInteractablesInRange();
    }

    InteractableItem closestInteractable;
    void UpdateInteractablesInRange ()
    {
        float maxDist = Mathf.Infinity;
        interactablesInRange.Clear();
        closestInteractable = null;
        foreach (InteractableItem item in InteractableItem.all)
        {
            float dist = Vector3.Distance(item.transform.position, transform.position);
            if (dist < interactionDist && item.interactable)
            {
                interactablesInRange.Add(item);

                if (dist < maxDist)
                {
                    maxDist = dist;
                    closestInteractable = item;
                }
            }
        }
    }

    public void InteractDown ()
    {
        if (itemInHand != null)
        {
            itemInHand.InteractDown();
        }
    }

    public void InteractUp ()
    {
        if (itemInHand != null)
        {
            itemInHand.InteractUp();
        }
    }

    public void HandActionDown ()
    {
        if (itemInHand == null)
        {
            if (closestInteractable != null)
            {
                itemInHand = closestInteractable;
                itemInHand.Grab(this);
            }
        }
    }

    public void HandActionUp ()
    {
        if (itemInHand != null)
        {
            itemInHand.Release();
            itemInHand = null;
        }
    }
}
