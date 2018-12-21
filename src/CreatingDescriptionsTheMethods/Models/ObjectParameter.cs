using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingDescriptionsTheMethods.Models
{
    public class ObjectParameter : TypeObjectParameter
    {
        public ObjectParameter()
        {
        }

        public ObjectParameter(string name)
        {
            Name = name;
        }

        public ObjectParameter(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public ObjectParameter(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public override string Name { get; set; }
        public override string Type { get; set; }
        public string Description { get; set; }
    }
}
