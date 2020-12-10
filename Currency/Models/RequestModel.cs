using System.Collections.Generic;

namespace Currency.Models
{
    public class RequestModel
    {
        public Dictionary<string, decimal> rates { get; set; } // имената на валутите и стойностите

        public string @base { get; set; } // индекс на изчиление

        public string date { get; set; } // дата на опресняване на данните 

        public override string ToString()
        {
            return $"{rates},{@base},{date}";
        }
    }
}
