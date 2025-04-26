using UnityEngine;

public class ToolButton : MonoBehaviour
{
    public int delta1;
    public int delta2;
    public int delta3;

    public void OnClick()
    {
        GameManager.Instance.lockController.UseTool(delta1, delta2, delta3);
    }
}