﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class CommandLine
    {
        public Guid Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PlatformName { get; set; }
        public string Comment { get; set; }
        public Guid PlatformId { get; set; }
        public virtual Platform Platform { get; set; }
    }
}