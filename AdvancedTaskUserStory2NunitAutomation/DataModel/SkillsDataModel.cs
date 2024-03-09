using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.DataModel
{
    public class SkillsDataModel
    {

        public string skillName { get; set; } = string.Empty;
        public string skillLevel { get; set; } = string.Empty;


        public void SetData(SkillsDataModel skillsDataModel)
        {
            skillName = skillsDataModel.skillName;
            skillLevel = skillsDataModel.skillLevel;

        }
        public SkillsDataModel GetData()
        {
            SkillsDataModel skillsDataModel = new SkillsDataModel();
            skillsDataModel.skillName = skillName;
            skillsDataModel.skillLevel = skillLevel;

            return skillsDataModel;
        }

    }
}
