using UnityEngine;

/*
 * Script in which describe character(teacher) behavior.
 */
public class Character : MonoBehaviour 
{
    public int costToBuy { get; private set; }
    public int attackDamage { get; private set; }
    public float radiusHit { get; private set; }
    public float attackSpeed { get; private set; }

    [SerializeField] private TeacherInfo teacherInfo;
    [SerializeField] private Transform turret; // An object that performs aiming and projectile generation
    [SerializeField] private GameObject shotPrefab; 
    [SerializeField] private GameObject radiusHitDisplay; // An object that displays the character's attack radius
    private GameObject radiusDisplay; // An object instance that displays the character's attack radius

    private GameObject shot;
    private float nextShoot = 0;
    private TargetPoint target;

    private Animator animator;
    private string animatorVar_attack = "isAttack";

    private void Awake()
    {
        if (teacherInfo != null)
        {
            animator = GetComponent<Animator>();
            costToBuy = teacherInfo.costToBuy;
            attackDamage = teacherInfo.damage;
            attackSpeed = teacherInfo.attackSpeed;
            radiusHit = teacherInfo.attackRadius;
        }
        else Debug.LogError($"Information about teacher was not set. Please check in prefab teacherInfo variable");
    }

    /// <summary>
    /// A method that generates an object that displays the character's attack radius and sets to positions 0, 0, 0 relative to the table.
    /// </summary>
    public void SetRadiusAttackDisplay()
    {
        radiusDisplay = Instantiate(radiusHitDisplay);
        DataManager.radiusAttackObjects.Add(radiusDisplay);

        radiusDisplay.transform.localScale = new Vector3(radiusHit * 2.2f, 0.5f, radiusHit * 2.2f);
        radiusDisplay.transform.SetParent(transform.parent.parent);
        radiusDisplay.transform.localPosition = Vector3.zero;
        radiusDisplay.transform.localPosition = Vector3.up*0.1f;
        radiusDisplay.SetActive(DataManager.isRadiusAttackDisplay);
    }

    public TeacherInfo GetNextTeacherInfo()
    {
        return teacherInfo.nextTeacherInfo;
    }

    private void LateUpdate()
    {
        if (isAcquireTarger() || isTargetTrucked())
            onAttack();
        else PlayAnimAttack(false);
    }

    private void onAttack()
    {
        if (target != null)
        {
            //PlayAnimAttack(true);
            turret.LookAt(target.position);
            var newRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.z = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15);
        }else PlayAnimAttack(false);

        if (Time.time > nextShoot)
        {
            shot = Instantiate(shotPrefab);
            shot.GetComponent<Shot>().target = target.transform;
            shot.GetComponent<Shot>().damage = attackDamage;
            shot.transform.rotation = turret.transform.rotation;
            shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
            nextShoot = Time.time + (1000 / attackSpeed) / 1000;
        }
    }

    // Find target to shoot
    private bool isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);

        if (targets.Length > 0)
        {
            target = FindTarger(targets).GetComponent<TargetPoint>();
            return true;
        }

        target = null;
        return false;
    }
    /// <summary>
    /// Find and return target to hit with lowest health percentage
    /// </summary>
    /// <param name="targets"></param>
    /// <returns>Collider targer</returns>
    private Collider FindTarger(Collider[] targets)
    {
        int index = targets.Length-1;
        int min_health = 0;
        for(int i = 0;i < targets.Length; i++)
        {
            int targetHealth = targets[i].GetComponent<Enemy>().GetHealthInProccent();
            if (targetHealth < min_health)
            {
                min_health = targetHealth;
                index = i;
            }
        }

        return targets[index];
    }

    private bool isTargetTrucked()
    {
        if (target == null)
            return false;
        else
        {
            Vector3 myPos = transform.localPosition;
            Vector3 targetPos = target.position;
            if (Vector3.Distance(myPos, targetPos) > radiusHit + target.colliderSize*target.enemy.scale) { 
                target = null;
                return false;
            }
        }

        return true;
    }

    public void DestroyCharacter()
    {
        ResourcesManager.Change(ResourceType.Money, costToBuy);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Destroy(radiusDisplay);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 pos = turret.position;
        pos.y += 0.01f;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
        if(target != null)
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(pos, target.position);
        }
    }

    private void PlayAnimAttack(bool flag)
    {
        animator?.SetBool(animatorVar_attack, flag);
        animator.speed = 1 / ((1000 / attackSpeed) / 1000)*2.75f;
    }
}
