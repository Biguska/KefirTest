public class ForgetSkillButton : AbstractActionButtonController
{
    public override void ButtonAction()
    {
        _skillTreeController.ForgetSkill();
    }

    protected override void CheckCondition(Skill skill)
    {
        if (skill.IsUnlocked && skill.IsAllChildLocked() && !skill.IsBase)
            SetButtonState(true);
        else
            SetButtonState(false);
    }
}
