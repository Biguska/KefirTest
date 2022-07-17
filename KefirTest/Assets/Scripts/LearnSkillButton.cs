public class LearnSkillButton : AbstractActionButtonController
{
    public override void ButtonAction()
    {
        _skillTreeController.LearnSkill();
    }

    protected override void CheckCondition(Skill skill)
    {
        if (!skill.IsUnlocked && skill.Price <= _skillTreeController.SkillPoints && skill.IsParentUnlocked() && !skill.IsBase)
            SetButtonState(true);
        else
            SetButtonState(false);
    }
}
