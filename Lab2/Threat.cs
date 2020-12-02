using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Threat
    {
        public static List<Threat> threats = new List<Threat>();

        public string ThreatId { get; set; }

        public string ThreatName { get; set; }

        public string ThreatDescription;

        public string ThreatSource;

        public string ThreatImpactObject;

        public string ConfidentialityViolation;

        public string IntegrityViolation;

        public string AccessibilityViolation;

        public Threat() { }

        public Threat(string threatId, string threatName, string threatDescription, string threatSource, string threatImpactObject, string confidentialityViolation, string integrityViolation, string accessibilityViolation)
        {
            ThreatId = "УБИ." + threatId;
            ThreatName = threatName;
            ThreatDescription = threatDescription;
            ThreatSource = threatSource;
            ThreatImpactObject = threatImpactObject;
            ConfidentialityViolation = PseudoBoolConverter(confidentialityViolation);
            IntegrityViolation = PseudoBoolConverter(integrityViolation);
            AccessibilityViolation = PseudoBoolConverter(accessibilityViolation);
            threats.Add(this);
        }

        private string PseudoBoolConverter(string str)
        {
            if (str == "0") return "Нет";
            else if (str == "1") return "Да";
            return null;
        }
    }
}
