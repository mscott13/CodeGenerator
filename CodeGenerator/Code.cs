using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator
{
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    [IgnoreFirst()]
    public class Code
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string code { get; set; }
    }
}
