﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreatingDescriptionsTheMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingDescriptionsTheMethods.Models.Tests
{
    [TestClass()]
    public class DataMethodTests
    {
        private List<string> _methodsNames = new List<string>();

        [TestMethod]
        public void EmptyDescription()
        {
            DataMethod methodEmpty = new DataMethod
            {
                StringMethod = "Метод()"
            };
            Assert.AreEqual(string.Empty, methodEmpty.Description);
        }

        [TestMethod()]
        public void NotEmptyDescription()
        {
            FillMethodNames();

            CheckFilledDescriptionMethodNames();
        }

        [TestMethod]
        public void NotEmptyDescriptionWithParameters()
        {
            FillMethodNames(true);

            CheckFilledDescriptionMethodNames();
        }

        private void CheckFilledDescriptionMethodNames()
        {
            foreach (string methodName in _methodsNames)
            {
                DataMethod method = new DataMethod
                {
                    StringMethod = methodName
                };
                WriteResultParseMethodName(method);

                Assert.AreNotEqual(string.Empty, method.Description);

                int countComma = methodName.Count(f => f == ',');
                if (countComma > 0)
                    Assert.AreEqual(++countComma, method.ParametersMethods.Count);
            }
        }

        private static void WriteResultParseMethodName(DataMethod method)
        {
            Console.WriteLine($"StringMethod:\n{method.StringMethod}");
            Console.WriteLine();
            Console.WriteLine($"Description:\n{method.Description}");
            Console.WriteLine();
            Console.WriteLine("Text error:");
            Console.WriteLine(method.TextError);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }

        private void FillMethodNames(bool addParameters = false)
        {
            _methodsNames.Clear();

            string[] typeMethods = new string[] { "Процедура", "Функция" };

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string typeMethod in typeMethods)
            {
                stringBuilder.Clear();

                stringBuilder.Append(typeMethod);
                stringBuilder.Append(" ");
                stringBuilder.Append("Метод");
                stringBuilder.Append("(");

                if (addParameters)
                {
                    AppendParameterMethod(stringBuilder, "мс"); 
                    AppendParameterMethod(stringBuilder, "со"); 
                    AppendParameterMethod(stringBuilder, "ст"); 
                    AppendParameterMethod(stringBuilder, "сз"); 
                    AppendParameterMethod(stringBuilder, "тз"); 
                    AppendParameterMethod(stringBuilder, "дз"); 

                    AppendParameterMethod(stringBuilder, "фмс");
                    AppendParameterMethod(stringBuilder, "фсо");
                    AppendParameterMethod(stringBuilder, "фст");

                    AppendParameterMethod(stringBuilder, "спр");
                    AppendParameterMethod(stringBuilder, "док");

                    AppendParameterMethod(stringBuilder, "дс"); 

                    AppendParameterMethod(stringBuilder, "ИмяПараметра"); 
                    AppendParameterMethod(stringBuilder, "Штрихкод"); 
                    AppendParameterMethod(stringBuilder, "ИмяКоманды"); 

                    AppendParameterMethod(stringBuilder, "отказ", false, "Ложь"); 
                }

                stringBuilder.Append(")");

                string methodName = stringBuilder.ToString();

                AddMethodWithCompilationDirectives(methodName);
                AddMethodWithCompilationDirectives($"{methodName} Экспорт ");
            }
       }

        private static void AppendParameterMethod(
            StringBuilder stringBuilder,
            string prefixParameter,
            bool addComma = true,
            string valueParameterByDefault = null)
        {
            string textDefaultValue = string.IsNullOrEmpty(valueParameterByDefault)
                ? ""
                : $" = {valueParameterByDefault}";

            stringBuilder.Append($"Знач {prefixParameter}Параметр{textDefaultValue}, ");
            stringBuilder.Append($"{prefixParameter}{textDefaultValue}{(addComma ? ", " : "")}");
        }

        private void AddMethodWithCompilationDirectives(string methodName)
        {
            _methodsNames.Add(methodName);

            _methodsNames.Add(
                "&НаКлиентеНаСервереБезКонтекста\n" +
                "" + methodName);

            _methodsNames.Add(
                "&НаСервереБезКонтекста\n" +
                "" + methodName);

            _methodsNames.Add(
                "&НаСервере\n" +
                "" + methodName);

            _methodsNames.Add(
                "&НаКлиенте\n" +
                "" + methodName);
        }

    }
}