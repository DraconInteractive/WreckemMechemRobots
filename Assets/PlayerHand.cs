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
    FixedJoint joint;

    private void Awake()
    {
        joint = GetComponent<FixedJoint>();
    }
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
        if (InteractableItem.all != null && InteractableItem.all.Count > 0)
        {
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

            foreach (InteractableItem item in InteractableItem.all)
            {
                if (chirality == Chirality.Left)
                {
                    item.highlightedLeft = false;
                } else
                {
                    item.highlightedRight = false;
                }
            }
            if (closestInteractable != null)
            {
                if (chirality == Chirality.Left)
                {
                    closestInteractable.highlightedLeft = true;
                }
                else
                {
                    closestInteractable.highlightedRight = true;
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
                if (closestInteractable.usePhysics)
                {
                    joint.connectedBody = closestInteractable.GetComponent<Rigidbody>();
                }
                
            }
        }
    }

    public void HandActionUp ()
    {
        if (itemInHand != null)
        {
            itemInHand.Release();
            itemInHand = null;
            
            if (joint.connectedBody != null)
            {
                joint.connectedBody = null;
            }
        }
    }
}
