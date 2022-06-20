using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    private float zCoord;
    private Vector3 offSet;
    public int damage { get; set; }

    [SerializeField]
    private GameObject meatballsEfectPrefab;

    private void Start()
    {
        DataManager.canMoveCamera = false;
    }

    private void OnDestroy()
    {
        GetComponent<SphereCollider>().enabled = true;

        if (DataManager.isNeedToDestroy)
        {
            float radiusHit = GetComponent<SphereCollider>().radius;

            Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);
            foreach (Collider target in targets)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
            }

            AbilitiesManager.GetAbility(Abilities.meatballsAbility).DeactivateAbility(Abilities.meatballsAbility);
        }

        Sprite sprite = AbilitiesManager.GetAbility(Abilities.meatballsAbility).artWork;
        UnityAction action = AbilitiesManager.GetAbility(Abilities.meatballsAbility).Use;
        AbilityDisplay.onChangeArtwork(Abilities.meatballsAbility, sprite, action);

        DataManager.canMoveCamera = true;
    }

    private void Update()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offSet = gameObject.transform.position - GetMouseWorldPos()*Time.deltaTime;

        if (Input.touchCount != 1)
        {
            return;
        }

        Touch touch = Input.touches[0];

        if (touch.phase == TouchPhase.Began)
        {
            zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            offSet = gameObject.transform.position - GetMouseWorldPos() * Time.deltaTime;
        }

        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 newPos = GetMouseWorldPos() - offSet * Time.deltaTime;
            newPos.y = 0.5f;
            transform.position = newPos;
        }

        if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            if (UIManager.IsPointerOverUIObject())
            {
                DataManager.isNeedToDestroy = false;
                Destroy(gameObject);
            }

           StartCoroutine(DestroyByTime(gameObject, 1.5f));
        }
    }

    /// <summary>
    /// Уничтожает объект по истечению времени
    /// </summary>
    /// <param name="duration">Время ожидания в секундах</param>
    /// <param name="target">Объект, который нужно уничтожить</param>
    /// <returns></returns>
    private IEnumerator DestroyByTime(GameObject target, float duration)
    {
        if (DataManager.isNeedToDestroy)
        {
            GetComponent<SphereCollider>().enabled = false;
            GameObject meatballs = Instantiate(meatballsEfectPrefab);
            meatballs.transform.position = transform.position;
            gameObject.GetComponent<DragObject>().enabled = false;
        }
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 pos = Input.mousePosition;

        pos.z = zCoord;

        return Camera.main.ScreenToWorldPoint(pos);
    }

    private void OnMouseUp()
    {
        StartCoroutine(DestroyByTime(gameObject, 1.5f));
    }
}
