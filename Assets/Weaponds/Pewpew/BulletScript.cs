

using UnityEngine;

public class BulletScript : ItemScript
{
    [SerializeField] float movementSpeed;
    private Vector3 _movement;
    private bool hasBeenShot = false;

    public override Activation getActivation()
    {
        return new Activation();
    }

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }


    public void shoot(IPlayer player)
    {
        transform.position = player.getPlayerHandsPosition();
        _movement = player.getDir();
        hasBeenShot = true;
        Vector3 dir = player.getDir().normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        if (n < 0) n += 360;

        transform.eulerAngles = new Vector3(0,0, n);
        Debug.Log(n);
        
        gameObject.SetActive(true);

    }

    public void Update()
    {
        if (hasBeenShot)
        {
            transform.position += _movement * Time.deltaTime * movementSpeed;
        }
    }




}
