using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput pInput;
    [SerializeField]
    public Ship shipDef;
    Weapon currentWeapon;
    [SerializeField]
    float thrust;
    float health;


    //to be removed once game manager is created
    [SerializeField]
    int playerNumber;

    [SerializeField]
    GameObject visuals;
    [SerializeField]
    float YawAngle;

    Vector2 thrustDirection;
    Vector2 rot;
    
    float angle = 0;
    
    Rigidbody rb;
    
    UInt16 weaponIndex = 0;
    Dictionary<Weapon, uint> AmmoReamainingOnSwitch;
    uint currentAmmo;
    float reloadTime;
    float fireRate;
    
    bool canFire = true;

    private void Start()
    {
        init();
    }

    private void Update()
    {
        thrustDirection = pInput.GetInput_LeftStick();
        rotate();
        actions();  
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(thrustDirection * thrust);
    }

    void actions()
    {
        //switch weapons
        if (pInput.getSwitchWeapons())
        {
            nextWeapon();
        }
        if (pInput.GetFire() > 0.1f)
        {
            if (canFire)
            {
                currentWeapon.fireWeapon(this);
            }
        }
        //temp code
        if (pInput.getReload())
        {
            StartCoroutine(reloadWeapon(reloadTime));
        }
        if (Input.GetButton("Fire1"))
        {
            if (canFire)
            {
                currentWeapon.fireWeapon(this);
            }
        }
    }

    void nextWeapon()
    {
        weaponIndex++;
        if (weaponIndex > shipDef.weapons.Length - 1)
        {
            weaponIndex = 0;
        }
        if (AmmoReamainingOnSwitch.ContainsKey(currentWeapon))
        {
            AmmoReamainingOnSwitch[currentWeapon] = currentAmmo;
        }
        else
        {
            AmmoReamainingOnSwitch.Add(currentWeapon, currentAmmo);
        }
        initWeapon(shipDef.weapons[weaponIndex]);
    }


    void rotate() {
        rot = pInput.GetInput_RightStick();
        if (rot.magnitude > 0)
        {
            angle = Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, -angle), 1);
        }
        visuals.transform.localEulerAngles = Vector3.Lerp(visuals.transform.eulerAngles, new Vector3(0, -thrustDirection.x * YawAngle, visuals.transform.localEulerAngles.z), 1);
    }

    public void init()
    {
        pInput = new PlayerInput(playerNumber);
        rb = GetComponent<Rigidbody>();
        AmmoReamainingOnSwitch = new Dictionary<Weapon, uint>();
        //set all Ship stats here
        thrust = shipDef.thrustForce;
        rb.mass = shipDef.mass;
        initWeapon(shipDef.weapons[weaponIndex]);
    }

    void initWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        fireRate = weapon.fireRate;
        if (AmmoReamainingOnSwitch.ContainsKey(currentWeapon))
        {
            currentAmmo = AmmoReamainingOnSwitch[currentWeapon];
        }
        else
        {
            currentAmmo = currentWeapon.maxAmmo;
        }
        print(currentAmmo.ToString());
    }

    public void ShootRailGun()
    {
        if (currentAmmo > 0 && canFire)
        {
            //instantiate the bullet
            //propell the bullet forward
            print("Charging " + currentWeapon.name);
            StartCoroutine(chargedShot(fireRate));
        }
    }

    public void ShootPlasmaShot()
    {
        if (currentAmmo > 0 && canFire)
        {
            //instantiate the bullet
            //propell the bullet forward
            print("fired " + currentWeapon.name);
            currentAmmo--;
            StartCoroutine(AutomaticFire(fireRate));
        }
    }

    public void ShootMachinegun()
    {
        if (currentAmmo > 0 && canFire)
        {
            //instantiate the bullet
            //propell the bullet forward
            print("fired " + currentWeapon.name);
            currentAmmo--;
            StartCoroutine(AutomaticFire(fireRate));
        }
    }

    IEnumerator reloadWeapon(float reloadTimer)
    {
        canFire = false;
        yield return new WaitForSeconds(reloadTimer);
        currentAmmo = currentWeapon.maxAmmo;
    }

    IEnumerator chargedShot(float timeTillShot)
    {
        canFire = false;
        yield return new WaitForSecondsRealtime(timeTillShot);
        print("fired " + currentWeapon.name);
        //instantiate bullet / projectile 
        currentAmmo--;
        canFire = true;
    }

    IEnumerator AutomaticFire(float firerate)
    {
        canFire = false;
        yield return new WaitForSeconds(firerate);
        canFire = true;
    }

    public void doDamage(float damage)
    {
        health -= damage;
    }
}
