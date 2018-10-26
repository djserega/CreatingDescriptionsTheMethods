using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingDescriptionsTheMethods.Models
{
    internal class ObjectParameter
    {
        public ObjectParameter()
        {
        }

        public ObjectParameter(string name)
        {
            Name = name;
        }

        public ObjectParameter(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public ObjectParameter(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        internal string Name { get; set; }
        internal string Type { get; set; }
        internal string Description { get; set; }

        internal bool IsArray { get => Name.ToLower().StartsWith("мс"); }
        internal bool IsMap { get => Name.ToLower().StartsWith("со"); }
        internal bool IsStructure { get => Name.ToLower().StartsWith("ст"); }
        internal bool IsValueList { get => Name.ToLower().StartsWith("сз"); }
        internal bool IsValueTable { get => Name.ToLower().StartsWith("тз"); }
        internal bool IsValueTree { get => Name.ToLower().StartsWith("дз"); }
        internal bool IsFixedArray { get => Name.ToLower().StartsWith("фмс"); }
        internal bool IsFixedMap { get => Name.ToLower().StartsWith("фсо"); }
        internal bool IsFixedStructure { get => Name.ToLower().StartsWith("фст"); }

        internal void SetTypeByName()
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
        }
    }
}
