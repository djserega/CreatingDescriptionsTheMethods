using CreatingDescriptionsTheMethods.Additions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreatingDescriptionsTheMethods.Models
{
    public class DataMethod : INotifyPropertyChanged
    {
        private string _stringMethod;
        private List<ObjectParameter> _parametersMethod = new List<ObjectParameter>();

        public string StringMethod { get => _stringMethod; set { _stringMethod = value; SetDescription(); } }
        public string Description { get; set; } = string.Empty;
        public string TextError { get; private set; } = string.Empty;
        public bool IncludeStringMethod { get; set; } = true;

        private bool StringIsFunction { get => StringMethod.TrimStart().StartsWith("функция", true, null); }
        private bool StringIsProcedure { get => StringMethod.TrimStart().StartsWith("процедура", true, null); }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void SetDescription()
        {
            TextError = string.Empty;
            Description = string.Empty;

            if (StringIsFunction || StringIsProcedure)
                CompileDescription();
            else
                TextError = "Строка метода должна начинаться со слова: 'Процедура' или 'Функция'.";
        }

        private void CompileDescription()
        {
            SetParametersMethod();

            StringBuilder builderDescription = new StringBuilder();

            builderDescription.AppendLine("// ");
            builderDescription.AppendLine("//");
            builderDescription.AppendLine("// Параметры:");

            if (_parametersMethod.Count == 0)
                builderDescription.AppendLine("//\t\t-  - ");
            else
                foreach (ObjectParameter parameter in _parametersMethod)
                    builderDescription.AppendLine($"//\t\t{parameter.Name} - {parameter.Type} - {parameter.Description}");

            if (StringIsFunction)
            {
                builderDescription.AppendLine("//");
                builderDescription.AppendLine("// Возвращаемое значение:");
                builderDescription.AppendLine("//\t\t - ");
            }

            builderDescription.AppendLine("//");

            Description = builderDescription.ToString();

            if (IncludeStringMethod)
                Description += _stringMethod;
        }

        private void SetParametersMethod()
        {
            _parametersMethod.Clear();

            string parser = _stringMethod;

            parser = parser.RemoveStartText("процедура");
            parser = parser.RemoveStartText("функция");
            parser = parser.TrimStart();

            int countOpeningBracket = parser.Count(f => f == '(');
            if (countOpeningBracket == 1)
            {
                int positionOpeningBracket = parser.IndexOf("(");

                parser = parser.RemoveSpace();
                parser = parser.Substring(positionOpeningBracket + 1);

                int countClosingBracket = parser.Count(f => f == ')');

                if (countClosingBracket == 1)
                {
                    parser = parser.Replace("\r", "");
                    parser = parser.Replace("\n", "");
                    parser = parser.Replace("\t", "");
                    parser = parser.TrimEnd(';');
                    parser = parser.TrimEnd(' ');
                    parser = parser.RemoveEndText("Экспорт");
                    parser = parser.TrimEnd(' ');
                    parser = parser.TrimEnd(')');

                    string[] parserParameters = parser.Split(',');
                    foreach (string itemParameter in parserParameters)
                        if (!string.IsNullOrWhiteSpace(itemParameter))
                        {
                            string paramenterName = itemParameter.RemoveStartText("знач").Trim();

                            int positionEqual = paramenterName.IndexOf('=');
                            if (positionEqual > 0)
                                paramenterName = paramenterName.Substring(0, positionEqual);

                            ObjectParameter objectParameter = new ObjectParameter(paramenterName);
                            objectParameter.SetTypeByName();

                            _parametersMethod.Add(objectParameter);
                        }
                }
            }
        }
    }
}
