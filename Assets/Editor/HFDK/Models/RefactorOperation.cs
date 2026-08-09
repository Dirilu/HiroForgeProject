namespace BRDK2.Models
{
    public enum RefactorOperationType
    {
        Namespace,
        Class,
        Struct,
        Interface,
        Enum,
        FileName,
        FolderName,
        MenuItem,
        WindowTitle,
        String,
        UXML,
        USS,
        AsmDef,
        Json
    }

    public class RefactorOperation
    {
        public RefactorOperationType Type;

        public string FilePath;

        public int Line;

        public string Before;

        public string After;

        public bool Selected = true;
    }
}