using System.Windows;

namespace dbSend.GUI
{
    /// <summary>
    ///     Interaction logic for ProcessWin.xaml
    /// </summary>
    public partial class ProcessWin : Window
    {
        private bool result;
        private readonly Reference reference;

        public ProcessWin(Reference ref1)
        {
            InitializeComponent();
            reference = ref1;
            DoIt();
        }

        internal void DoIt()
        {
            result = reference.DoIt;
        }
    }
}