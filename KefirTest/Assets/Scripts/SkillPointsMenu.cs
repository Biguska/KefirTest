using TMPro;
using UnityEngine;
using Zenject;

public class SkillPointsMenu : MonoBehaviour
{
    [Inject] private readonly SkillTreeController _skillTreeController;

    [SerializeField] private TextMeshProUGUI _countLabel;

    private void OnEnable()
    {
        _skillTreeController.OnSkillPointsUpdate += UpdateCount;
    }

    private void OnDisable()
    {
        _skillTreeController.OnSkillPointsUpdate -= UpdateCount;
    }

    private void UpdateCount(int count)
    {
        _countLabel.text = count.ToString();
    }

    public void EarnSkillPoint()
    {
        _skillTreeController.UpdateSkillPoints(1);
    }
}
