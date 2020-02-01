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
    public float movementSpeed, rotateSpeed;
    public UnityEvent onInteractDown, onInteractUp;

    public GameObject highlightLeft, highlightRight;
    public bool highlightedLeft, highlightedRight;

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
        StartCoroutine(HighlightRoutine());
    }

    IEnumerator CooldownRoutine ()
    {
        while (true)
        {
            if (currentCooldown > 0)
            {
                currentCooldown -= Time.deltaTime;
            }
            yield return null;
        }
        yield break;
    }

    IEnumerator MovementRoutine ()
    {
        while (true)
        {
            if (grabbed)
            {
                transform.position = Vector3.MoveTowards(transform.position, grabbingHand.itemAnchor.position, movementSpeed * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, grabbingHand.itemAnchor.rotation, rotateSpeed * Time.deltaTime);
            }
            yield return null;
        }
        
        yield break;
    }

    IEnumerator HighlightRoutine ()
    {
        while (true)
        {
            if (highlightedLeft)
            {
                if (!highlightLeft.activeSelf)
                {
                    highlightLeft.SetActive(true);
                }
            } else
            {
                if (highlightLeft.activeSelf)
                {
                    highlightLeft.SetActive(false);
                }
            }

            if (highlightedRight)
            {
                if (!highlightRight.activeSelf)
                {
                    highlightRight.SetActive(true);
                }
            } else
            {
                if (highlightRight.activeSelf)
                {
                    highlightRight.SetActive(false);
                }
            }
            yield return null;
        }
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
