namespace JoF.Rail.Core.Models
{
    using System.Collections.Generic;

    public class OperatorCodes
    {
        public IEnumerable<Ooperator> Operators { get; set; }

        public class Ooperator
        {
            public string Code { get; set; }

            public string Name { get; set; }
        }
    }
}