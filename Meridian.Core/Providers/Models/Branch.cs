using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meridian.Core.Providers.Models
{
    public class Branch
    {
        public string Name { get; set; } = string.Empty;
        public string CommitSha { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public bool IsProtected { get; set; }
        public DateTime LastCommitAt { get; set; }
        public string LastCommitMessage { get; set; } = string.Empty;
        public string LastCommitAuthor { get; set; } = string.Empty;
    }
}
