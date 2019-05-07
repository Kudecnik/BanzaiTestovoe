using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CannonHolder : MonoBehaviour
{
    [SerializeField] private Transform _cannonsHolderTransform;

    private readonly List<CannonController> _cannonsControllers = new List<CannonController>();
    private CannonController _activeCannon;
    private int _currentCannonIndex;

    public CannonController ActiveCannon
    {
        get { return _activeCannon; }
    }

    private void Start()
    {
        var cannonsSettings = Resources.LoadAll("Cannons", typeof(CannonSetting)).Cast<CannonSetting>();

        foreach (var cannonsSetting in cannonsSettings)
        {
            var cannon = Instantiate(cannonsSetting.CannonPrefab, _cannonsHolderTransform);

            cannon.SetActive(false);
            
            var controller = cannon.GetComponent<CannonController>();
            
            controller.Init(cannonsSetting);
            _cannonsControllers.Add(controller);
        }

        var firstCannon = _cannonsControllers[0];

        firstCannon.gameObject.SetActive(true);
        _activeCannon = firstCannon.GetComponent<CannonController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCannonBackward();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCannonForward();
        }
    }

    private void SwitchCannonForward()
    {
        _currentCannonIndex++;

        if (_currentCannonIndex > _cannonsControllers.Count - 1)
        {
            _currentCannonIndex = 0;
        }

        _activeCannon = _cannonsControllers[_currentCannonIndex];
    }

    private void SwitchCannonBackward()
    {
        _currentCannonIndex--;
        if (_currentCannonIndex < 0)
        {
            _currentCannonIndex = _cannonsControllers.Count - 1;
        }

        _activeCannon = _cannonsControllers[_currentCannonIndex];
    }
}