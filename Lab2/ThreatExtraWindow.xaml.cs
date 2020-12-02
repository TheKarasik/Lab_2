using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для ThreatExtraWindow.xaml
    /// </summary>
    public partial class ThreatExtraWindow : Window
    {
        public ThreatExtraWindow()
        {
            InitializeComponent();

            List<ThreatDescriber> threatDescribers = new List<ThreatDescriber>();
            Threat threat = MainWindow.choosenThreat;
            threatDescribers.Add(new ThreatDescriber("Идентификатор угрозы: ", threat.ThreatId));
            threatDescribers.Add(new ThreatDescriber("Наименование угрозы: ", threat.ThreatName));
            threatDescribers.Add(new ThreatDescriber("Описание угрозы: ", threat.ThreatDescription));
            threatDescribers.Add(new ThreatDescriber("Источник угрозы: ", threat.ThreatSource));
            threatDescribers.Add(new ThreatDescriber("Объект воздействия угрозы: ", threat.ThreatImpactObject));
            threatDescribers.Add(new ThreatDescriber("Нарушение конфиденциальности: ", threat.ConfidentialityViolation));
            threatDescribers.Add(new ThreatDescriber("Нарушение целостности: ", threat.IntegrityViolation));
            threatDescribers.Add(new ThreatDescriber("Нарушение доступности : ", threat.AccessibilityViolation));
            listView.ItemsSource = threatDescribers;
        }
    }
}
