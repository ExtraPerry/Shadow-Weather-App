using UnityEngine;
using UnityEngine.UI;

public class SideBar : UpdatableMono
{
    [SerializeField]
    WeatherCurrentInfo weatherCurrentInfo;
    [SerializeField]
    private Image icon;

    private void Awake()
    {
        icon.sprite = Resources.Load<Sprite>("Sprites/day/0");
    }

    public override void TriggerUpdate(Component sender, object data)
    {
        if (sender is WeatherCurrentRequester)
        {
            ResetRetryAttempts();
            TriggerUpdate();
        }
    }

    public override void TriggerUpdate()
    {
        if (weatherCurrentInfo is null)
        {
            Debug.LogError("\"Weather Current Info\" is not assigned in \"" + gameObject.name + "\" inspector window.");
            return;
        }
        if (!weatherCurrentInfo.IsCompletedOnce())
        {
            StartCoroutine(RetryAttempt());
            return;
        }

        Sprite icon;
        WeatherCurrent data = weatherCurrentInfo.data;
        if (data.current.temp_c <= 10 || data.current.temp_c >= 25)
        {
            ColdHot choice = (data.current.temp_c <= 10) ? ColdHot.Cold : ColdHot.Hot;
            icon = WeatherApiUtility.GetHotOrColdSprite(choice);
        }
        else
        {
            icon = WeatherApiUtility.GetIconSprite(data.current.condition.code, data.current.is_day == 1);
        }
        this.icon.sprite = icon;
    }
}
