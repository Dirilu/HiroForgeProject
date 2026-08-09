using System;

namespace BRDK2.Models
{
    public class CommandAction
    {
        public string Title;
        public string Description;
        public string Icon;

        public Action Execute;

        public CommandAction(
            string title,
            string description,
            string icon,
            Action execute)
        {
            Title = title;
            Description = description;
            Icon = icon;
            Execute = execute;
        }
    }
}