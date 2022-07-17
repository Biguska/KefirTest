using UnityEngine;
using Zenject;

public class ForgetAllSkillsButton : MonoBehaviour
{
    [Inject] private readonly SkillTreeController _skillTreeController;

    public void ButtonAction()
    {
        _skillTreeController.ForgetAllSkills();
    }
}
