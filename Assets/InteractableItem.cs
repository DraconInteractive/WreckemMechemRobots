using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public static List<InteractableItem> all = new List<InteractableItem>();
    public bool interactable = true;
    public float actionCooldown;
    float currentCooldown;
    public float movementSpeed;
    public UnityEvent onInteractDown, onInteractUp;

    private void Awake()
    {
        if (!all.Contains(this))
        {
            all.Add(this);
        }
    }

    private void Start()
    {
        StartCoroutine(CooldownRoutine());
        StartCoroutine(MovementRoutine());
    }

    IEnumerator CooldownRoutine ()
    {
        while (true)
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
        }
        yield break;
    }

    IEnumerator MovementRoutine ()
    {
        if (grabbed)
        {
            transform.position = Vector3.MoveTowards(transform.position, grabbingHand.itemAnchor.position, movementSpeed * Time.deltaTime);
        }
        yield break;
    }

    private void OnDestroy()
    {
        if (all.Contains(this))
        {
            all.Remove(this);
        }
    }

    public void InteractDown ()
    {
        onInteractDown?.Invoke();
        currentCooldown = actionCooldown;
    }

    public void InteractUp ()
    {
        onInteractUp?.Invoke();
    }

    PlayerHand grabbingHand;
    bool grabbed;
    public void Grab (PlayerHand hand)
    {
        grabbed = true;
        grabbingHand = hand;
    }

    public void Release ()
    {
        grabbed = false;
    }
}
