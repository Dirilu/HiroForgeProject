using System;

namespace BRDK2.Models
{
    [Serializable]
    public class RefactorItem
    {
        public bool Selected = true;

        public string FilePath;

        public int LineNumber;

        public string OriginalText;

        public string PreviewText;

        public string ReplaceText;
    }
}