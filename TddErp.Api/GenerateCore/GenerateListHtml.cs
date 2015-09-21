using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TddErp.Api.GenerateCore
{
    public class GenerateListHtml<T> where T : class
    {
        private string dataTypeAtt = string.Empty;
        private string requireAtt = string.Empty;
        private int minLengthAtt = 0;
        private int maxLengthAtt = 0;
        private bool isGenerate = true;
        string modelName = string.Empty;
        string hasClassName = string.Empty;
        StringBuilder input = new StringBuilder();
        TagBuilder label;
        private StringBuilder result = new StringBuilder();

        public string GetAddOrEdit(string ngModelState,string hasClassName)
        {
            result.Clear();
            this.hasClassName = hasClassName;
            foreach (var prop in typeof(T).GetProperties())
            {
                input.Clear();
                modelName = prop.Name;
                label = new TagBuilder("label");
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs == null || attrs.Length == 0) continue;
                SetInputTypeByDefault(prop);
                foreach (Attribute attr in attrs)
                {
                    SetLabel(attr);
                    if (attr is DataTypeAttribute)
                    {
                        SetInputTypeByAttribute(attr);
                    }
                    SetValidateAttribute(attr);
                }
                if (isGenerate)
                {
                    switch (dataTypeAtt)
                    {
                        case "date":
                            AddKinDatePicker(ngModelState);
                            break;
                        default:
                            AddInputAttribute(ngModelState);
                            break;
                    }
                }
            }
            return result.ToString();
        }

        public string GetList()
        {
            result.Clear();
            result.AppendLine(@"<table class=""table"">");
            TagBuilder titleName = new TagBuilder("tr");
            TagBuilder modelName = new TagBuilder("tr");
            modelName.Attributes.Add("ng-repeat", "item in ctrl.users track by item.id");
            titleName.InnerHtml = "\r\n";
            modelName.InnerHtml = "\r\n";
            foreach (var prop in typeof(T).GetProperties())
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs == null || attrs.Length == 0) continue;
                foreach (var attr in attrs)
                {
                    if (attr is DisplayAttribute)
                    {
                        titleName.InnerHtml += string.Format("<th>{0}</th>\r\n", (attr as DisplayAttribute).Name);
                    }
                }
                modelName.InnerHtml += string.Format("<td>{{item.{0}}}</td>\r\n", prop.Name);
            }
            result.AppendLine(titleName.ToString());
            result.AppendLine(modelName.ToString());
            result.Append("</table>");
            return result.ToString();
        }

        private void SetInputTypeByDefault(System.Reflection.PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
            {
                dataTypeAtt = "text";
            }
            else if (prop.PropertyType == typeof(bool))
            {
                dataTypeAtt = "checkbox";
            }
            else
            {
                dataTypeAtt = "number";
            }
            isGenerate = true;
            minLengthAtt = 0;
            maxLengthAtt = 0;
            requireAtt = string.Empty;
        }

        private void AddInputAttribute(string ngModelState)
        {
            if (hasClassName != null)
            {
                input.AppendFormat("<input type='{0}' class='form-control' name='{3}' ng-model='ctrl.{1}.{2}.{3}'", dataTypeAtt,
                ngModelState, hasClassName, modelName);
            }
            else
            {
                input.AppendFormat("<input type='{0}' class='form-control' name='{2}' ng-model='ctrl.{1}.{2}'", dataTypeAtt,
                ngModelState, modelName);
            }
           
            if (!string.IsNullOrEmpty(requireAtt))
            {
                input.Append(" required");
            }
            if (minLengthAtt > 0)
            {
                input.AppendFormat(" ng-minlength='{0}'", minLengthAtt);
            }
            if (maxLengthAtt > 0)
            {
                input.AppendFormat(" ng-maxlength='{0}'", maxLengthAtt);
            }
            input.Append(" />");
            result.AppendLine(@"<div class=""form-group"">");
            result.AppendLine(label.ToString());
            result.AppendLine(input.ToString());
            AppendNgMessage(modelName);
            result.AppendLine("</div>");
        }

        void AddKinDatePicker(string ngModelState)
        {
            if (hasClassName != null)
            {
                input.AppendFormat(@"<kin-date-picker kin-name=""{0}"" model=""ctrl.{1}.{3}.{0}""" +
                    @" open=""ctrl.{0}Opened"" btn-click=""ctrl.{0}Open($event)"" is-required=""{2}""></kin-date-picker>",
                    modelName, ngModelState, requireAtt == "require"?"true":"false",hasClassName);
            }
            else
            {
                input.AppendFormat(@"<kin-date-picker kin-name=""{0}"" model=""ctrl.{1}.{0}""" +
                    @" open=""ctrl.{0}Opened"" btn-click=""ctrl.{0}Open($event)"" is-required=""{2}""></kin-date-picker>",
                    modelName, ngModelState, requireAtt == "require"?"true":"false");
            }
            result.AppendLine(label.ToString());
            result.AppendLine(input.ToString());
            AppendNgMessage(modelName);
        }

        private void AppendNgMessage(string modelName)
        {
            result.AppendFormat(@"<div ng-messages=""myForm.{0}.$error"" class=""error"" ng-show=""myForm.{0}.$dirty"">", modelName).AppendLine();
            result.AppendLine(@"<p ng-messages-include=""{{ngMessagePath}}""></p></div>");
        }

        void SetLabel(Attribute attr)
        {
            if (attr is DisplayAttribute)
            {
                label.SetInnerText((attr as DisplayAttribute).Name);
            }
        }

        private void SetValidateAttribute(Attribute attr)
        {  
            if (attr is RequiredAttribute)
            {
                requireAtt = "require";
            }
            else if (attr is MaxLengthAttribute)
            {
                maxLengthAtt = (attr as MaxLengthAttribute).Length;
            }
            else if (attr is MinLengthAttribute)
            {
                minLengthAtt = (attr as MinLengthAttribute).Length;
            }
            else if (attr is ScaffoldColumnAttribute)
            {
                isGenerate = false;
            }
        }

        private void SetInputTypeByAttribute(Attribute attr)
        {
            switch ((attr as DataTypeAttribute).DataType)
            {
                case DataType.Password:
                    dataTypeAtt = "password";
                    break;
                case DataType.EmailAddress:
                    dataTypeAtt = "email";
                    break;
                case DataType.DateTime:
                    dataTypeAtt = "datetime";
                    break;
                case DataType.Date:
                    dataTypeAtt = "date";
                    break;
            }
        }
    }
}