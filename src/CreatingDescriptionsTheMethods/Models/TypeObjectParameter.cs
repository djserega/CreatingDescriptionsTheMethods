using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingDescriptionsTheMethods.Models
{
    public abstract class TypeObjectParameter
    {
        public abstract string Name { get; set; }
        public abstract string Type { get; set; }

        public bool IsArray { get => NameStartsWith("мс"); }
        public bool IsMap { get => NameStartsWith("со"); }
        public bool IsStructure { get => NameStartsWith("ст"); }
        public bool IsValueList { get => NameStartsWith("сз"); }
        public bool IsValueTable { get => NameStartsWith("тз"); }
        public bool IsValueTree { get => NameStartsWith("дз"); }

        public bool IsFixedArray { get => NameStartsWith("фмс"); }
        public bool IsFixedMap { get => NameStartsWith("фсо"); }
        public bool IsFixedStructure { get => NameStartsWith("фст"); }

        public bool IsReference { get => NameStartsWith("спр"); }
        public bool IsDocument { get => NameStartsWith("док"); }

        public bool IsDynamicList { get => NameStartsWith("дс"); }


        public bool IsString
        {
            get
            {
                switch (Name)
                {
                    case "ИмяПараметра":
                    case "Штрихкод":
                    case "ИмяКоманды":
                        return true;
                    default:
                        return false;
                }
            }
        }
        public bool IsBoolean { get => Name.ToUpper() == "ОТКАЗ"; }


        private bool NameStartsWith(string text) => Name.StartsWith(text, true, null);

        public void SetTypeByName()
        {
            if (IsArray)
                Type = "Массив";
            else if (IsMap)
                Type = "Соответствие";
            else if (IsStructure)
                Type = "Структура";
            else if (IsValueList)
                Type = "СписокЗначений";
            else if (IsValueTable)
                Type = "ТаблицаЗначений";
            else if (IsValueTree)
                Type = "ДеревоЗначений";
            else if (IsFixedArray)
                Type = "ФиксированныйМассив";
            else if (IsFixedMap)
                Type = "ФиксированноеСоответствие";
            else if (IsFixedStructure)
                Type = "ФиксированнаяСтруктура";

            else if (IsReference)
                Type = "СправочникСсылка";
            else if (IsDocument)
                Type = "ДокументСсылка";

            else if (IsDynamicList)
                Type = "ДинамическийСписок";

            else if (IsString)
                Type = "Строка";
            else if (IsBoolean)
                Type = "Булево";

        }

    }
}
