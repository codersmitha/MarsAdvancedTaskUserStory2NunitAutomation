using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿

namespace MarsAdvancedTaskPart1NUnitAutomation.DataModel
{

    public class LanguageDataModel
    {
        public string language { get; set; } = string.Empty;
        public string level { get; set; } = string.Empty;


        public void SetData(LanguageDataModel languageDataModel)
        {
            language = languageDataModel.language;
            level = languageDataModel.level;

        }
        public LanguageDataModel GetData()
        {
            LanguageDataModel languageDataModel = new LanguageDataModel();
            languageDataModel.language = language;
            languageDataModel.level = level;

            return languageDataModel;
        }


    }
}