using System.Collections.Generic;

namespace BRDK2.Models
{
    public class RefactorJob
    {
        public string Name;

        public string Find;

        public string Replace;

        public bool RenameNamespaces = true;

        public bool RenameClasses = true;

        public bool RenameFiles = true;

        public bool RenameStrings = true;

        public bool RenameMenus = true;

        public bool RenameUXML = true;

        public bool RenameUSS = true;

        public bool RenameAsmDef = true;

        public List<RefactorItem> Results = new();
    }
}