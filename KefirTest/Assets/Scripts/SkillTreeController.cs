using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeController : MonoBehaviour
{
    public event Action<Skill> OnSkillSelected;
    public event Action<int> OnSkillPointsUpdate;

    [SerializeField] private TextMeshProUGUI _skillPriceLabel;
    [SerializeField] private List<Skill> _skills = new List<Skill>();

    private int _skillPoints = 0;
    private Skill _selectedSkill;

    public int SkillPoints => _skillPoints;

    private void Start()
    {
        UpdateSkillPoints(0);
    }

    public void SelectSkill(Skill skill)
    {
        if(_selectedSkill != null)
            _selectedSkill.SetSelectState(false);
        _selectedSkill = skill;

        if (_selectedSkill.IsBase)
            _skillPriceLabel.text = "Выберите умение";
        else
            _skillPriceLabel.text = String.Format("Стоимость: {0}", _selectedSkill.Price);

        RefreshButtons();
    }

    public void LearnSkill()
    {
        UpdateSkillPoints(_selectedSkill.Price * -1);
        _selectedSkill.SetUnlockState(true);
        RefreshButtons();
    }

    public void ForgetSkill()
    {
        UpdateSkillPoints(_selectedSkill.Price);
        _selectedSkill.SetUnlockState(false);
        RefreshButtons();
    }

    public void ForgetAllSkills()
    {
        _skills.ForEach(skill =>
        {
            if (skill.IsUnlocked && !skill.IsBase)
            {
                skill.SetUnlockState(false);
                UpdateSkillPoints(skill.Price);
            }
        });
        RefreshButtons();
    }

    private void RefreshButtons()
    {
        OnSkillSelected.Invoke(_selectedSkill);
    }

    public void UpdateSkillPoints(int point)
    {
        _skillPoints += point;
        OnSkillPointsUpdate.Invoke(_skillPoints);
        RefreshButtons();
    }
}
