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

        public ObjectParameter(string name) : this()
        {
            Name = name;
        }

        public ObjectParameter(string name, string type) : this(name)
        {
            Type = type;
        }

        public ObjectParameter(string name, string type, string description) : this(name, type)
        {
            Description = description;
        }

        public override string Name { get; set; }
        public override string Type { get; set; }
        public string Description { get; set; }
    }
}
