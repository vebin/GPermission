namespace GPermission.Domain.AppSystems
{
    public class AppSystemEditableInfo
    {
        public string Name { get; set; }

        public string ReMark { get; set; }

        public AppSystemEditableInfo(string name, string reMark = "")
        {
            Name = name;
            ReMark = reMark;
        }
    }
}
