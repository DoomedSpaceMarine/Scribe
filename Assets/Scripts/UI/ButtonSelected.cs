using UnityEngine;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour
{
    private EventManager _eventManager;
    [SerializeField] private ButtonType buttonType;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }
    
    public void SetButtonSelected()
    {
        _eventManager.SetButtonSelected(buttonType, this.gameObject.GetComponent<Button>());
    }
}
