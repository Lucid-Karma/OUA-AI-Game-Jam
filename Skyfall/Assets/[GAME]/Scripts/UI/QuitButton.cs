using UnityEngine;
using UnityEngine.UI;

public class QuitButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(Finish);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(Finish);
    }

    public void Finish()
    {
        Application.Quit();
    }
}
