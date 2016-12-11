﻿using System;

namespace Lexn.Lexis.Model
{
    public class Identifier
    {
        public Guid IdentifierID { get; set; }

        public string Name { get; set; }

        public IdentifierType Type { get; set; }
    }
}