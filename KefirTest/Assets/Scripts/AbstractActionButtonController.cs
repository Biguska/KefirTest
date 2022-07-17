using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AbstractActionButtonController : MonoBehaviour
{
    [Inject] protected readonly SkillTreeController _skillTreeController;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _skillTreeController.OnSkillSelected += CheckCondition;
    }

    private void OnDisable()
    {
        _skillTreeController.OnSkillSelected -= CheckCondition;
    }

    public virtual void ButtonAction() { }

    protected virtual void CheckCondition(Skill skill) { }

    protected void SetButtonState(bool state)
    {
        _button.interactable = state;
    }
}
