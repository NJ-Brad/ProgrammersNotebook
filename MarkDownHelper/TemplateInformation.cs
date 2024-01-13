using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MarkDownHelper
{
    public class TemplateInformation
    {
        public string Category { get; set; } = string.Empty;
        string description;
        public string Description {
            get { return String.IsNullOrEmpty(description) ? FileName : description; } 
            set { description = value; } 
        }
        public string FileName{get;set; } = string.Empty;
        public string Source { get; set; } = "Original";        // choices are Original, Based On, Copied
        public string Origin { get; set;} = string.Empty;
        public int TimesUsed { get; set; }= 0;
        public string AdditionalInfo { get; set; } = string.Empty;
    }
}
