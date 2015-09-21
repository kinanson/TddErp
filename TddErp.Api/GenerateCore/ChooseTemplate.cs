using System.Text;
using TddErp.Model.Models;

namespace TddErp.Api.GenerateCore
{
    public class ChooseTemplate
    {
        public static string GetMasterTemplate()
        {
            StringBuilder result = new StringBuilder();
            GenerateListHtml<Employee> generateListHtml = new GenerateListHtml<Employee>();
            result.AppendLine("新增部份");
            result.AppendLine(generateListHtml.GetAddOrEdit("add", "member"));
            result.AppendLine();
            result.AppendLine();
            result.AppendLine("顯示部份");
            result.AppendLine(generateListHtml.GetList());
            result.AppendLine();
            result.AppendLine();
            result.AppendLine("修改部份");
            result.AppendLine(generateListHtml.GetAddOrEdit("edit", "member"));
            return result.ToString();
        }
    }
}