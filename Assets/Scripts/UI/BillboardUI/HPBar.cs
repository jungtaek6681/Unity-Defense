using UnityEngine;
using UnityEngine.UI;

public class HPBar : BillboardUI
{
    [SerializeField] Monster monster;

    private void Start()
    {
        GetUI<Slider>("Slider").maxValue = monster.HP;
        GetUI<Slider>("Slider").value = monster.HP;
    }

    private void OnEnable()
    {
        SetHP(monster.HP);
        monster.OnHPChanged += SetHP;
    }

    private void OnDisable()
    {
        monster.OnHPChanged -= SetHP;
    }

    public void SetHP(int hp)
    {
        GetUI<Slider>("Slider").value = hp;
    }
}
