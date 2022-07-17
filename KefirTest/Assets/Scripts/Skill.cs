using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Skill : MonoBehaviour
{
    [Inject] private readonly SkillTreeController _skillTreeController;

    [SerializeField] private string _skillName;
    [SerializeField] private TextMeshProUGUI _nameLabel;

    [SerializeField] private bool _isBase = false;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _selectedObj;
    [SerializeField] private GameObject _lockedObj;

    [SerializeField] private List<Skill> _parentSkills = new List<Skill>();
    [SerializeField] private List<Skill> _childSkills = new List<Skill>();

    private bool _isUnlocked = false;
    private bool _isSelected = false;

    public int Price => _price;

    public bool IsBase => _isBase;

    public bool IsUnlocked => _isUnlocked;

    private void Awake()
    {
        _nameLabel.text = _skillName;

        if (_isBase)
        {
            SetUnlockState(true);
            SelectSkill();
        }
        else
            SetUnlockState(false);
    }

    public void ButtonAction()
    {
        if (!_isSelected)
        {
            SelectSkill();
        }
    }

    private void SelectSkill()
    {
        _skillTreeController.SelectSkill(this);
        SetSelectState(true);
    }

    public void SetSelectState(bool state)
    {
        _isSelected = state;
        _selectedObj.SetActive(state);
    }

    public void SetUnlockState(bool state)
    {
        _lockedObj.SetActive(!state);
        _isUnlocked = state;
    }

    public bool IsParentUnlocked()
    {
        var skill = _parentSkills.Find(skill => skill.IsUnlocked == true);

        if (skill != null)
            return true;
        else
            return false;
    }

    public bool IsAllChildLocked()
    {
        var skill = _childSkills.Find(skill => skill.IsUnlocked == true);

        if (skill != null)
            return false;
        else
            return true;
    }
}
