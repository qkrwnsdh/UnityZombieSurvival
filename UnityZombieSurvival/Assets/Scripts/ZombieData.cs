using UnityEngine;

// 좀비 생성시 사용할 셋업 데이터
[CreateAssetMenu(menuName = "Scriptable/ZombieData", fileName = "Zombie Data")]
public class ZombieData : ScriptableObject {

    public float health = 100f; // 체력
    public float damage = 20f; // 공격력
    public float speed = 2f; // 이동 속도
    public Color skinColor = Color.white; // 피부색
     
    public ZombieData(float health_ ,float damage_ ,float speed_, Color skinColor_) 
    {
        this.health = health_;
        this.damage = damage_;
        this.speed = speed_;
        this.skinColor = skinColor_;
    }
}

enum ZombieLoadIndex
{
    ZOMBIE_HEALTH = 1,
    ZOMBIE_DAMAGE,
    ZOMBIE_SPEED,
    ZOMBIE_COLOR
}


public class ZombieData2
{
    public float health = default; // 체력
    public float damage = default;// 공격력
    public float speed = default; // 이동 속도
    public Color skinColor = default; // 피부색


    public ZombieData2(string zombieDataStr)
    {

        string[] zombieDatas_str = zombieDataStr.Split(',');

        //{ Zombie data를 초기화 하는 로직

        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_HEALTH], out health);
        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_DAMAGE], out damage);
        float.TryParse(zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_SPEED], out speed);

        //{ colorHtmlCode를 불러왔을 때 같이 존재하는 쓰레기 값을 제거하는 로직
        string colorHtmlCode = zombieDatas_str[(int)ZombieLoadIndex.ZOMBIE_COLOR];
        colorHtmlCode = colorHtmlCode.Substring(0, 6);
        colorHtmlCode = string.Format("#{0}FF", colorHtmlCode);
        //} colorHtmlCode를 불러왔을 때 같이 존재하는 쓰레기 값을 제거하는 로직

        ColorUtility.TryParseHtmlString(colorHtmlCode, out skinColor);
        //} Zombie data를 초기화 하는 로직

        //{ 예외처리
        bool isInvalid = Mathf.Approximately(health, 0f) ||
            (Mathf.Approximately(damage, 0f) && Mathf.Approximately(speed, 0f));
        if (isInvalid == true)
        {
            Debug.LogErrorFormat("[ZombieData2] Can't initialize ZombieData");
            Debug.Assert(isInvalid);

        }
        //} 예외처리

    }//ZombieData2)_
}

