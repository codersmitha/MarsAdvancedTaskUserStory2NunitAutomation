using AdvancedTaskUserStory2NunitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using Newtonsoft.Json;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskUserStory2NunitAutomation.Utilities
{
    public class JSONDataReader
    {
        public string jsonFilePath = string.Empty;


        public List<LanguageDataModel> ReadLJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<LanguageDataModel> language = JsonConvert.DeserializeObject<List<LanguageDataModel>>(json)!;
            return language;
        }
        public List<SkillsDataModel> ReadSJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<SkillsDataModel> skills = JsonConvert.DeserializeObject<List<SkillsDataModel>>(json);
            return skills;
        }

        public List<ShareSkillsDataModel> ReadShareSKillsJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<ShareSkillsDataModel> shareSkillsList = JsonConvert.DeserializeObject<List<ShareSkillsDataModel>>(json);
            return shareSkillsList;
        }
        public LoginDataModel ReadLoginJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            LoginDataModel loginInfo = JsonConvert.DeserializeObject<LoginDataModel>(json)!;
            return loginInfo;
        }
        public void SetDataPath(string typeDM)
        {
            string path = Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            if (typeDM.Equals("language"))
                jsonFilePath = projectPath + @"TestData\LanguageData.json";
            else if (typeDM.Equals("skills"))
                jsonFilePath = projectPath + @"TestData\SkillsData.json";
            else if (typeDM.Equals("shareskills"))
                jsonFilePath = projectPath + @"TestData\ShareSkillsData.json";
            else if (typeDM.Equals("login"))
                jsonFilePath = projectPath + @"TestData\LoginInformationData.json";
        }
    }
}
