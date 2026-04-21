using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meridian.Core.Providers.Models
{
    public class Repository
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string CloneUrl { get; set; } = string.Empty;
        public string DefaultBranch { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}
